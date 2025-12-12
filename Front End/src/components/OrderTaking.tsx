import { useState } from 'react';
import { Minus, Plus, ShoppingCart, Trash2, X } from 'lucide-react';
import { Card, CardContent, CardHeader, CardTitle } from './ui/card';
import { Button } from './ui/button';
import { Badge } from './ui/badge';
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogFooter } from './ui/dialog';
import { Input } from './ui/input';
import { Label } from './ui/label';

interface MenuItem {
  id: string;
  name: string;
  price: number;
  category: string;
  image?: string;
}

interface OrderItem extends MenuItem {
  quantity: number;
}

interface Promotion {
  id: string;
  name: string;
  discount: number;
  type: 'percentage' | 'fixed';
}

export function OrderTaking() {
  const [selectedCategory, setSelectedCategory] = useState('Todos');
  const [orderItems, setOrderItems] = useState<OrderItem[]>([]);
  const [showCheckout, setShowCheckout] = useState(false);
  const [customerName, setCustomerName] = useState('');
  const [paymentMethod, setPaymentMethod] = useState('efectivo');

  const categories = ['Todos', 'Hamburguesas', 'Pizzas', 'Bebidas', 'Acompañamientos', 'Combos'];

  const menuItems: MenuItem[] = [
    { id: '1', name: 'Hamburguesa Clásica', price: 8.99, category: 'Hamburguesas' },
    { id: '2', name: 'Hamburguesa Doble', price: 12.99, category: 'Hamburguesas' },
    { id: '3', name: 'Pizza Personal', price: 10.50, category: 'Pizzas' },
    { id: '4', name: 'Pizza Familiar', price: 22.99, category: 'Pizzas' },
    { id: '5', name: 'Papas Fritas', price: 3.99, category: 'Acompañamientos' },
    { id: '6', name: 'Aros de Cebolla', price: 4.50, category: 'Acompañamientos' },
    { id: '7', name: 'Refresco', price: 2.50, category: 'Bebidas' },
    { id: '8', name: 'Jugo Natural', price: 3.50, category: 'Bebidas' },
    { id: '9', name: 'Combo Burger', price: 15.99, category: 'Combos' },
    { id: '10', name: 'Combo Familiar', price: 45.99, category: 'Combos' },
  ];

  const promotions: Promotion[] = [
    { id: '1', name: 'Descuento 10%', discount: 10, type: 'percentage' },
    { id: '2', name: 'Descuento $5', discount: 5, type: 'fixed' },
  ];

  const [appliedPromotion, setAppliedPromotion] = useState<Promotion | null>(null);

  const filteredItems = selectedCategory === 'Todos'
    ? menuItems
    : menuItems.filter(item => item.category === selectedCategory);

  const addToOrder = (item: MenuItem) => {
    const existingItem = orderItems.find(orderItem => orderItem.id === item.id);
    if (existingItem) {
      setOrderItems(orderItems.map(orderItem =>
        orderItem.id === item.id
          ? { ...orderItem, quantity: orderItem.quantity + 1 }
          : orderItem
      ));
    } else {
      setOrderItems([...orderItems, { ...item, quantity: 1 }]);
    }
  };

  const updateQuantity = (id: string, delta: number) => {
    setOrderItems(orderItems.map(item =>
      item.id === id
        ? { ...item, quantity: Math.max(0, item.quantity + delta) }
        : item
    ).filter(item => item.quantity > 0));
  };

  const removeItem = (id: string) => {
    setOrderItems(orderItems.filter(item => item.id !== id));
  };

  const subtotal = orderItems.reduce((sum, item) => sum + item.price * item.quantity, 0);
  
  const discount = appliedPromotion
    ? appliedPromotion.type === 'percentage'
      ? subtotal * (appliedPromotion.discount / 100)
      : appliedPromotion.discount
    : 0;

  const total = subtotal - discount;

  const handleCheckout = () => {
    if (orderItems.length === 0) return;
    setShowCheckout(true);
  };

  const completeOrder = () => {
    // Aquí se procesaría la orden
    alert(`Pedido completado para ${customerName || 'Cliente'}. Total: $${total.toFixed(2)}`);
    setOrderItems([]);
    setAppliedPromotion(null);
    setCustomerName('');
    setShowCheckout(false);
  };

  return (
    <div className="p-8 h-full">
      <div className="mb-6">
        <h1 className="text-gray-900 mb-2">Tomar Pedido</h1>
        <p className="text-gray-600">Selecciona productos y procesa la venta</p>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-6 h-[calc(100vh-200px)]">
        {/* Menú de productos */}
        <div className="lg:col-span-2 flex flex-col overflow-hidden">
          <div className="flex gap-2 mb-4 overflow-x-auto pb-2">
            {categories.map(category => (
              <button
                key={category}
                onClick={() => setSelectedCategory(category)}
                className={`px-4 py-2 rounded-lg whitespace-nowrap transition-colors ${
                  selectedCategory === category
                    ? 'bg-orange-600 text-white'
                    : 'bg-white text-gray-600 hover:bg-gray-100'
                }`}
              >
                {category}
              </button>
            ))}
          </div>

          <div className="grid grid-cols-2 md:grid-cols-3 gap-4 overflow-y-auto">
            {filteredItems.map(item => (
              <Card
                key={item.id}
                className="cursor-pointer hover:shadow-lg transition-shadow"
                onClick={() => addToOrder(item)}
              >
                <CardContent className="p-4">
                  <div className="aspect-square bg-gray-200 rounded-lg mb-3 flex items-center justify-center">
                    <ShoppingCart className="w-8 h-8 text-gray-400" />
                  </div>
                  <h3 className="text-gray-900 mb-1">{item.name}</h3>
                  <Badge variant="secondary" className="text-xs mb-2">{item.category}</Badge>
                  <p className="text-orange-600">${item.price.toFixed(2)}</p>
                </CardContent>
              </Card>
            ))}
          </div>
        </div>

        {/* Carrito de pedido */}
        <div className="lg:col-span-1 flex flex-col">
          <Card className="flex-1 flex flex-col">
            <CardHeader className="border-b">
              <CardTitle className="flex items-center gap-2">
                <ShoppingCart className="w-5 h-5" />
                Pedido Actual
              </CardTitle>
            </CardHeader>
            <CardContent className="flex-1 overflow-y-auto p-4">
              {orderItems.length === 0 ? (
                <div className="text-center text-gray-500 py-8">
                  <ShoppingCart className="w-12 h-12 mx-auto mb-2 text-gray-300" />
                  <p>No hay productos en el pedido</p>
                </div>
              ) : (
                <div className="space-y-3">
                  {orderItems.map(item => (
                    <div key={item.id} className="bg-gray-50 p-3 rounded-lg">
                      <div className="flex justify-between items-start mb-2">
                        <span className="text-gray-900">{item.name}</span>
                        <button
                          onClick={() => removeItem(item.id)}
                          className="text-red-500 hover:text-red-700"
                        >
                          <Trash2 className="w-4 h-4" />
                        </button>
                      </div>
                      <div className="flex justify-between items-center">
                        <div className="flex items-center gap-2">
                          <button
                            onClick={() => updateQuantity(item.id, -1)}
                            className="w-7 h-7 bg-white rounded border flex items-center justify-center hover:bg-gray-100"
                          >
                            <Minus className="w-3 h-3" />
                          </button>
                          <span className="w-8 text-center">{item.quantity}</span>
                          <button
                            onClick={() => updateQuantity(item.id, 1)}
                            className="w-7 h-7 bg-white rounded border flex items-center justify-center hover:bg-gray-100"
                          >
                            <Plus className="w-3 h-3" />
                          </button>
                        </div>
                        <span className="text-gray-900">
                          ${(item.price * item.quantity).toFixed(2)}
                        </span>
                      </div>
                    </div>
                  ))}
                </div>
              )}
            </CardContent>

            <div className="border-t p-4 space-y-3">
              <div className="space-y-2">
                <label className="text-sm text-gray-600">Aplicar Promoción</label>
                <div className="flex gap-2">
                  {promotions.map(promo => (
                    <button
                      key={promo.id}
                      onClick={() => setAppliedPromotion(appliedPromotion?.id === promo.id ? null : promo)}
                      className={`flex-1 px-3 py-2 rounded text-sm transition-colors ${
                        appliedPromotion?.id === promo.id
                          ? 'bg-green-600 text-white'
                          : 'bg-gray-100 text-gray-700 hover:bg-gray-200'
                      }`}
                    >
                      {promo.name}
                    </button>
                  ))}
                </div>
              </div>

              <div className="space-y-1">
                <div className="flex justify-between text-gray-600">
                  <span>Subtotal:</span>
                  <span>${subtotal.toFixed(2)}</span>
                </div>
                {appliedPromotion && (
                  <div className="flex justify-between text-green-600">
                    <span>Descuento:</span>
                    <span>-${discount.toFixed(2)}</span>
                  </div>
                )}
                <div className="flex justify-between text-gray-900 pt-2 border-t">
                  <span>Total:</span>
                  <span className="text-xl">${total.toFixed(2)}</span>
                </div>
              </div>

              <Button
                onClick={handleCheckout}
                disabled={orderItems.length === 0}
                className="w-full bg-orange-600 hover:bg-orange-700"
              >
                Procesar Venta
              </Button>
            </div>
          </Card>
        </div>
      </div>

      {/* Modal de checkout */}
      <Dialog open={showCheckout} onOpenChange={setShowCheckout}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Completar Venta</DialogTitle>
          </DialogHeader>
          <div className="space-y-4 py-4">
            <div className="space-y-2">
              <Label htmlFor="customer">Nombre del Cliente (Opcional)</Label>
              <Input
                id="customer"
                value={customerName}
                onChange={(e) => setCustomerName(e.target.value)}
                placeholder="Ingresa el nombre"
              />
            </div>
            <div className="space-y-2">
              <Label>Método de Pago</Label>
              <div className="grid grid-cols-2 gap-2">
                <button
                  onClick={() => setPaymentMethod('efectivo')}
                  className={`p-3 rounded border ${
                    paymentMethod === 'efectivo'
                      ? 'border-orange-600 bg-orange-50 text-orange-600'
                      : 'border-gray-200 hover:bg-gray-50'
                  }`}
                >
                  Efectivo
                </button>
                <button
                  onClick={() => setPaymentMethod('tarjeta')}
                  className={`p-3 rounded border ${
                    paymentMethod === 'tarjeta'
                      ? 'border-orange-600 bg-orange-50 text-orange-600'
                      : 'border-gray-200 hover:bg-gray-50'
                  }`}
                >
                  Tarjeta
                </button>
              </div>
            </div>
            <div className="bg-gray-50 p-4 rounded-lg">
              <div className="flex justify-between text-gray-900 mb-2">
                <span>Total a Pagar:</span>
                <span className="text-2xl">${total.toFixed(2)}</span>
              </div>
            </div>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setShowCheckout(false)}>
              Cancelar
            </Button>
            <Button onClick={completeOrder} className="bg-orange-600 hover:bg-orange-700">
              Confirmar Venta
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}
