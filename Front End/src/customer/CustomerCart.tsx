import { Minus, Plus, Trash2, ShoppingBag } from 'lucide-react';
import { CustomerViewType, CartItem } from './CustomerApp';
import { Card, CardContent, CardHeader, CardTitle } from '../components/ui/card';
import { Button } from '../components/ui/button';

interface CustomerCartProps {
  items: CartItem[];
  onUpdateQuantity: (id: string, quantity: number) => void;
  onNavigate: (view: CustomerViewType) => void;
}

export function CustomerCart({ items, onUpdateQuantity, onNavigate }: CustomerCartProps) {
  const subtotal = items.reduce((sum, item) => sum + item.price * item.quantity, 0);
  const deliveryFee = subtotal >= 25 ? 0 : 3.00;
  const total = subtotal + deliveryFee;

  if (items.length === 0) {
    return (
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
        <Card>
          <CardContent className="py-16 text-center">
            <ShoppingBag className="w-16 h-16 text-gray-300 mx-auto mb-4" />
            <h2 className="text-gray-900 mb-2">Tu carrito está vacío</h2>
            <p className="text-gray-600 mb-6">Agrega productos del menú para continuar</p>
            <Button
              onClick={() => onNavigate('menu')}
              className="bg-orange-600 hover:bg-orange-700"
            >
              Ver Menú
            </Button>
          </CardContent>
        </Card>
      </div>
    );
  }

  return (
    <div className="max-w-4xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
      <div className="mb-8">
        <h1 className="text-gray-900 mb-2">Carrito de Compras</h1>
        <p className="text-gray-600">Revisa tu pedido antes de continuar</p>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
        {/* Cart Items */}
        <div className="lg:col-span-2 space-y-4">
          {items.map(item => (
            <Card key={item.id}>
              <CardContent className="p-6">
                <div className="flex gap-4">
                  <div className="w-20 h-20 bg-gradient-to-br from-orange-100 to-orange-200 rounded-lg flex items-center justify-center text-3xl flex-shrink-0">
                    {item.category === 'Hamburguesas' && '🍔'}
                    {item.category === 'Pizzas' && '🍕'}
                    {item.category === 'Bebidas' && '🥤'}
                    {item.category === 'Acompañamientos' && '🍟'}
                    {item.category === 'Combos' && '🍱'}
                  </div>
                  <div className="flex-1">
                    <h3 className="text-gray-900 mb-1">{item.name}</h3>
                    <p className="text-sm text-gray-600 mb-3">{item.description}</p>
                    <div className="flex items-center justify-between">
                      <div className="flex items-center gap-2">
                        <button
                          onClick={() => onUpdateQuantity(item.id, item.quantity - 1)}
                          className="w-8 h-8 bg-gray-100 rounded-full flex items-center justify-center hover:bg-gray-200"
                        >
                          <Minus className="w-4 h-4" />
                        </button>
                        <span className="w-12 text-center text-gray-900">{item.quantity}</span>
                        <button
                          onClick={() => onUpdateQuantity(item.id, item.quantity + 1)}
                          className="w-8 h-8 bg-gray-100 rounded-full flex items-center justify-center hover:bg-gray-200"
                        >
                          <Plus className="w-4 h-4" />
                        </button>
                      </div>
                      <div className="flex items-center gap-4">
                        <p className="text-xl text-gray-900">
                          ${(item.price * item.quantity).toFixed(2)}
                        </p>
                        <button
                          onClick={() => onUpdateQuantity(item.id, 0)}
                          className="text-red-500 hover:text-red-700"
                        >
                          <Trash2 className="w-5 h-5" />
                        </button>
                      </div>
                    </div>
                  </div>
                </div>
              </CardContent>
            </Card>
          ))}
        </div>

        {/* Order Summary */}
        <div className="lg:col-span-1">
          <Card className="sticky top-20">
            <CardHeader>
              <CardTitle>Resumen del Pedido</CardTitle>
            </CardHeader>
            <CardContent>
              <div className="space-y-3 mb-6">
                <div className="flex justify-between text-gray-600">
                  <span>Subtotal</span>
                  <span>${subtotal.toFixed(2)}</span>
                </div>
                <div className="flex justify-between text-gray-600">
                  <span>Envío</span>
                  <span>{deliveryFee === 0 ? 'GRATIS' : `$${deliveryFee.toFixed(2)}`}</span>
                </div>
                {subtotal < 25 && deliveryFee > 0 && (
                  <p className="text-xs text-gray-500">
                    Agrega ${(25 - subtotal).toFixed(2)} más para envío gratis
                  </p>
                )}
                <div className="border-t pt-3">
                  <div className="flex justify-between text-gray-900">
                    <span>Total</span>
                    <span className="text-2xl">${total.toFixed(2)}</span>
                  </div>
                </div>
              </div>
              <Button
                onClick={() => onNavigate('checkout')}
                className="w-full bg-orange-600 hover:bg-orange-700 mb-3"
              >
                Proceder al Pago
              </Button>
              <Button
                onClick={() => onNavigate('menu')}
                variant="outline"
                className="w-full"
              >
                Agregar Más Productos
              </Button>
            </CardContent>
          </Card>
        </div>
      </div>
    </div>
  );
}
