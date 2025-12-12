import { useState } from 'react';
import { Plus, Search } from 'lucide-react';
import { CustomerViewType, CartItem } from './CustomerApp';
import { Card, CardContent } from '../components/ui/card';
import { Button } from '../components/ui/button';
import { Input } from '../components/ui/input';
import { Badge } from '../components/ui/badge';
import { toast } from 'sonner';

interface MenuItem {
  id: string;
  name: string;
  description: string;
  price: number;
  category: string;
}

interface CustomerMenuProps {
  onAddToCart: (item: Omit<CartItem, 'quantity'>) => void;
  onNavigate: (view: CustomerViewType) => void;
}

export function CustomerMenu({ onAddToCart, onNavigate }: CustomerMenuProps) {
  const [selectedCategory, setSelectedCategory] = useState('Todos');
  const [searchTerm, setSearchTerm] = useState('');

  const categories = ['Todos', 'Hamburguesas', 'Pizzas', 'Combos', 'Bebidas', 'Acompañamientos'];

  const menuItems: MenuItem[] = [
    { id: '1', name: 'Hamburguesa Clásica', description: 'Carne, lechuga, tomate, queso', price: 8.99, category: 'Hamburguesas' },
    { id: '2', name: 'Hamburguesa Doble', description: 'Doble carne, queso, pepinillos', price: 12.99, category: 'Hamburguesas' },
    { id: '3', name: 'Pizza Personal', description: 'Pizza individual con ingredientes a elegir', price: 10.50, category: 'Pizzas' },
    { id: '4', name: 'Pizza Familiar', description: 'Pizza grande para compartir', price: 22.99, category: 'Pizzas' },
    { id: '5', name: 'Papas Fritas', description: 'Papas crujientes con sal', price: 3.99, category: 'Acompañamientos' },
    { id: '6', name: 'Refresco', description: 'Bebida gaseosa 500ml', price: 2.50, category: 'Bebidas' },
    { id: '7', name: 'Jugo Natural', description: 'Jugo de frutas naturales', price: 3.50, category: 'Bebidas' },
    { id: '8', name: 'Combo Burger', description: 'Hamburguesa + Papas + Refresco', price: 15.99, category: 'Combos' },
    { id: '9', name: 'Combo Familiar', description: '2 Hamburguesas + Papas Grande + 2 Bebidas', price: 45.99, category: 'Combos' },
  ];

  const filteredItems = menuItems.filter(item => {
    const matchesCategory = selectedCategory === 'Todos' || item.category === selectedCategory;
    const matchesSearch = item.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
                         item.description.toLowerCase().includes(searchTerm.toLowerCase());
    return matchesCategory && matchesSearch;
  });

  const handleAddToCart = (item: MenuItem) => {
    onAddToCart({
      id: item.id,
      name: item.name,
      description: item.description,
      price: item.price,
      category: item.category,
    });
    toast.success(`${item.name} agregado al carrito`);
  };

  return (
    <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
      <div className="mb-8">
        <h1 className="text-gray-900 mb-2">Nuestro Menú</h1>
        <p className="text-gray-600">Selecciona tus productos favoritos</p>
      </div>

      {/* Search */}
      <div className="mb-6">
        <div className="relative max-w-md">
          <Search className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 w-5 h-5" />
          <Input
            placeholder="Buscar productos..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            className="pl-10"
          />
        </div>
      </div>

      {/* Categories */}
      <div className="mb-8 flex gap-2 overflow-x-auto pb-2">
        {categories.map(category => (
          <button
            key={category}
            onClick={() => setSelectedCategory(category)}
            className={`px-6 py-2 rounded-full whitespace-nowrap transition-colors ${
              selectedCategory === category
                ? 'bg-orange-600 text-white'
                : 'bg-white text-gray-600 border border-gray-300 hover:border-orange-600'
            }`}
          >
            {category}
          </button>
        ))}
      </div>

      {/* Menu Items */}
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {filteredItems.map(item => (
          <Card key={item.id} className="hover:shadow-lg transition-shadow">
            <CardContent className="p-6">
              <div className="aspect-square bg-gradient-to-br from-orange-100 to-orange-200 rounded-lg mb-4 flex items-center justify-center text-6xl">
                {item.category === 'Hamburguesas' && '🍔'}
                {item.category === 'Pizzas' && '🍕'}
                {item.category === 'Bebidas' && '🥤'}
                {item.category === 'Acompañamientos' && '🍟'}
                {item.category === 'Combos' && '🍱'}
              </div>
              <div className="mb-4">
                <Badge variant="secondary" className="mb-2">{item.category}</Badge>
                <h3 className="text-gray-900 mb-1">{item.name}</h3>
                <p className="text-sm text-gray-600 mb-3">{item.description}</p>
                <p className="text-2xl text-orange-600">${item.price.toFixed(2)}</p>
              </div>
              <Button
                onClick={() => handleAddToCart(item)}
                className="w-full bg-orange-600 hover:bg-orange-700"
              >
                <Plus className="w-4 h-4 mr-2" />
                Agregar al Carrito
              </Button>
            </CardContent>
          </Card>
        ))}
      </div>

      {filteredItems.length === 0 && (
        <div className="text-center py-12">
          <p className="text-gray-500">No se encontraron productos</p>
        </div>
      )}
    </div>
  );
}
