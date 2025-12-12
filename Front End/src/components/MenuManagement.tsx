import { useState } from 'react';
import { Plus, Pencil, Trash2, Search } from 'lucide-react';
import { Card, CardContent, CardHeader, CardTitle } from './ui/card';
import { Button } from './ui/button';
import { Input } from './ui/input';
import { Label } from './ui/label';
import { Badge } from './ui/badge';
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogFooter } from './ui/dialog';
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select';

interface Product {
  id: string;
  name: string;
  category: string;
  price: number;
  available: boolean;
}

export function MenuManagement() {
  const [products, setProducts] = useState<Product[]>([
    { id: '1', name: 'Hamburguesa Clásica', category: 'Hamburguesas', price: 8.99, available: true },
    { id: '2', name: 'Hamburguesa Doble', category: 'Hamburguesas', price: 12.99, available: true },
    { id: '3', name: 'Pizza Personal', category: 'Pizzas', price: 10.50, available: true },
    { id: '4', name: 'Pizza Familiar', category: 'Pizzas', price: 22.99, available: true },
    { id: '5', name: 'Papas Fritas', category: 'Acompañamientos', price: 3.99, available: true },
    { id: '6', name: 'Aros de Cebolla', category: 'Acompañamientos', price: 4.50, available: false },
    { id: '7', name: 'Refresco', category: 'Bebidas', price: 2.50, available: true },
    { id: '8', name: 'Jugo Natural', category: 'Bebidas', price: 3.50, available: true },
  ]);

  const [searchTerm, setSearchTerm] = useState('');
  const [showDialog, setShowDialog] = useState(false);
  const [editingProduct, setEditingProduct] = useState<Product | null>(null);
  const [formData, setFormData] = useState({
    name: '',
    category: '',
    price: '',
  });

  const categories = ['Hamburguesas', 'Pizzas', 'Bebidas', 'Acompañamientos', 'Combos'];

  const filteredProducts = products.filter(product =>
    product.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
    product.category.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const openDialog = (product?: Product) => {
    if (product) {
      setEditingProduct(product);
      setFormData({
        name: product.name,
        category: product.category,
        price: product.price.toString(),
      });
    } else {
      setEditingProduct(null);
      setFormData({ name: '', category: '', price: '' });
    }
    setShowDialog(true);
  };

  const handleSave = () => {
    if (!formData.name || !formData.category || !formData.price) {
      alert('Por favor completa todos los campos');
      return;
    }

    if (editingProduct) {
      setProducts(products.map(p =>
        p.id === editingProduct.id
          ? { ...p, name: formData.name, category: formData.category, price: parseFloat(formData.price) }
          : p
      ));
    } else {
      const newProduct: Product = {
        id: Date.now().toString(),
        name: formData.name,
        category: formData.category,
        price: parseFloat(formData.price),
        available: true,
      };
      setProducts([...products, newProduct]);
    }
    setShowDialog(false);
  };

  const toggleAvailability = (id: string) => {
    setProducts(products.map(p =>
      p.id === id ? { ...p, available: !p.available } : p
    ));
  };

  const deleteProduct = (id: string) => {
    if (confirm('¿Estás seguro de eliminar este producto?')) {
      setProducts(products.filter(p => p.id !== id));
    }
  };

  return (
    <div className="p-8">
      <div className="mb-6">
        <h1 className="text-gray-900 mb-2">Gestión de Menú</h1>
        <p className="text-gray-600">Administra los productos disponibles</p>
      </div>

      <div className="mb-6 flex gap-4">
        <div className="flex-1 relative">
          <Search className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 w-5 h-5" />
          <Input
            placeholder="Buscar productos..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            className="pl-10"
          />
        </div>
        <Button onClick={() => openDialog()} className="bg-orange-600 hover:bg-orange-700">
          <Plus className="w-4 h-4 mr-2" />
          Nuevo Producto
        </Button>
      </div>

      <Card>
        <CardContent className="p-0">
          <div className="overflow-x-auto">
            <table className="w-full">
              <thead className="bg-gray-50 border-b">
                <tr>
                  <th className="text-left p-4 text-gray-600">Producto</th>
                  <th className="text-left p-4 text-gray-600">Categoría</th>
                  <th className="text-left p-4 text-gray-600">Precio</th>
                  <th className="text-left p-4 text-gray-600">Estado</th>
                  <th className="text-right p-4 text-gray-600">Acciones</th>
                </tr>
              </thead>
              <tbody>
                {filteredProducts.map((product) => (
                  <tr key={product.id} className="border-b last:border-0 hover:bg-gray-50">
                    <td className="p-4">
                      <span className="text-gray-900">{product.name}</span>
                    </td>
                    <td className="p-4">
                      <Badge variant="secondary">{product.category}</Badge>
                    </td>
                    <td className="p-4">
                      <span className="text-gray-900">${product.price.toFixed(2)}</span>
                    </td>
                    <td className="p-4">
                      <button
                        onClick={() => toggleAvailability(product.id)}
                        className={`px-3 py-1 rounded-full text-sm ${
                          product.available
                            ? 'bg-green-100 text-green-700'
                            : 'bg-red-100 text-red-700'
                        }`}
                      >
                        {product.available ? 'Disponible' : 'No Disponible'}
                      </button>
                    </td>
                    <td className="p-4">
                      <div className="flex justify-end gap-2">
                        <Button
                          variant="ghost"
                          size="sm"
                          onClick={() => openDialog(product)}
                        >
                          <Pencil className="w-4 h-4" />
                        </Button>
                        <Button
                          variant="ghost"
                          size="sm"
                          onClick={() => deleteProduct(product.id)}
                        >
                          <Trash2 className="w-4 h-4 text-red-500" />
                        </Button>
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </CardContent>
      </Card>

      <Dialog open={showDialog} onOpenChange={setShowDialog}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>
              {editingProduct ? 'Editar Producto' : 'Nuevo Producto'}
            </DialogTitle>
          </DialogHeader>
          <div className="space-y-4 py-4">
            <div className="space-y-2">
              <Label htmlFor="name">Nombre del Producto</Label>
              <Input
                id="name"
                value={formData.name}
                onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                placeholder="Ej: Hamburguesa Clásica"
              />
            </div>
            <div className="space-y-2">
              <Label htmlFor="category">Categoría</Label>
              <Select
                value={formData.category}
                onValueChange={(value) => setFormData({ ...formData, category: value })}
              >
                <SelectTrigger>
                  <SelectValue placeholder="Selecciona una categoría" />
                </SelectTrigger>
                <SelectContent>
                  {categories.map(category => (
                    <SelectItem key={category} value={category}>
                      {category}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-2">
              <Label htmlFor="price">Precio</Label>
              <Input
                id="price"
                type="number"
                step="0.01"
                value={formData.price}
                onChange={(e) => setFormData({ ...formData, price: e.target.value })}
                placeholder="0.00"
              />
            </div>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setShowDialog(false)}>
              Cancelar
            </Button>
            <Button onClick={handleSave} className="bg-orange-600 hover:bg-orange-700">
              {editingProduct ? 'Guardar Cambios' : 'Crear Producto'}
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}
