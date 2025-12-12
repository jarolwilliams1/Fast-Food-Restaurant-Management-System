import { useState } from 'react';
import { Clock, CheckCircle, XCircle, Eye, Truck } from 'lucide-react';
import { Card, CardContent, CardHeader, CardTitle } from '../components/ui/card';
import { Badge } from '../components/ui/badge';
import { Button } from '../components/ui/button';
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogFooter } from '../components/ui/dialog';
import { Tabs, TabsContent, TabsList, TabsTrigger } from '../components/ui/tabs';

interface OnlineOrder {
  id: string;
  orderNumber: string;
  customer: {
    name: string;
    phone: string;
    address: string;
  };
  items: { name: string; quantity: number; price: number }[];
  subtotal: number;
  delivery: number;
  total: number;
  status: 'pending' | 'preparing' | 'ready' | 'delivering' | 'completed' | 'cancelled';
  time: string;
  paymentMethod: string;
}

export function OnlineOrdersManagement() {
  const [orders, setOrders] = useState<OnlineOrder[]>([
    {
      id: '1',
      orderNumber: '#WEB-045',
      customer: { name: 'María García', phone: '555-0123', address: 'Av. Principal #123, Col. Centro' },
      items: [
        { name: 'Combo Burger', quantity: 1, price: 15.99 },
        { name: 'Papas Fritas', quantity: 1, price: 3.99 },
      ],
      subtotal: 19.98,
      delivery: 3.00,
      total: 22.98,
      status: 'pending',
      time: '11:30',
      paymentMethod: 'Tarjeta Online',
    },
    {
      id: '2',
      orderNumber: '#WEB-046',
      customer: { name: 'Juan Pérez', phone: '555-0456', address: 'Calle 5 #456, Col. Norte' },
      items: [
        { name: 'Pizza Familiar', quantity: 1, price: 22.99 },
        { name: 'Refresco', quantity: 2, price: 2.50 },
      ],
      subtotal: 27.99,
      delivery: 3.00,
      total: 30.99,
      status: 'preparing',
      time: '11:42',
      paymentMethod: 'Efectivo',
    },
    {
      id: '3',
      orderNumber: '#WEB-047',
      customer: { name: 'Ana López', phone: '555-0789', address: 'Blvd. Sur #789, Col. Sur' },
      items: [
        { name: 'Hamburguesa Doble', quantity: 2, price: 12.99 },
      ],
      subtotal: 25.98,
      delivery: 3.00,
      total: 28.98,
      status: 'ready',
      time: '11:55',
      paymentMethod: 'Tarjeta Online',
    },
    {
      id: '4',
      orderNumber: '#WEB-048',
      customer: { name: 'Carlos Ruiz', phone: '555-0321', address: 'Av. Este #321, Col. Este' },
      items: [
        { name: 'Combo Familiar', quantity: 1, price: 45.99 },
      ],
      subtotal: 45.99,
      delivery: 3.00,
      total: 48.99,
      status: 'delivering',
      time: '12:03',
      paymentMethod: 'Efectivo',
    },
  ]);

  const [selectedOrder, setSelectedOrder] = useState<OnlineOrder | null>(null);
  const [activeTab, setActiveTab] = useState('all');

  const updateOrderStatus = (orderId: string, newStatus: OnlineOrder['status']) => {
    setOrders(orders.map(order => 
      order.id === orderId ? { ...order, status: newStatus } : order
    ));
    setSelectedOrder(null);
  };

  const getStatusColor = (status: string) => {
    switch (status) {
      case 'pending': return 'bg-blue-100 text-blue-700';
      case 'preparing': return 'bg-yellow-100 text-yellow-700';
      case 'ready': return 'bg-green-100 text-green-700';
      case 'delivering': return 'bg-purple-100 text-purple-700';
      case 'completed': return 'bg-gray-100 text-gray-700';
      case 'cancelled': return 'bg-red-100 text-red-700';
      default: return 'bg-gray-100 text-gray-700';
    }
  };

  const getStatusLabel = (status: string) => {
    switch (status) {
      case 'pending': return 'Pendiente';
      case 'preparing': return 'Preparando';
      case 'ready': return 'Listo';
      case 'delivering': return 'En Camino';
      case 'completed': return 'Completado';
      case 'cancelled': return 'Cancelado';
      default: return status;
    }
  };

  const filterOrders = (status?: string) => {
    if (!status || status === 'all') return orders;
    return orders.filter(order => order.status === status);
  };

  const filteredOrders = filterOrders(activeTab);

  return (
    <div className="p-8">
      <div className="mb-6">
        <h1 className="text-gray-900 mb-2">Gestión de Pedidos Online</h1>
        <p className="text-gray-600">Administra los pedidos realizados desde la página web</p>
      </div>

      <Tabs value={activeTab} onValueChange={setActiveTab} className="mb-6">
        <TabsList>
          <TabsTrigger value="all">Todos ({orders.length})</TabsTrigger>
          <TabsTrigger value="pending">Pendientes ({orders.filter(o => o.status === 'pending').length})</TabsTrigger>
          <TabsTrigger value="preparing">Preparando ({orders.filter(o => o.status === 'preparing').length})</TabsTrigger>
          <TabsTrigger value="ready">Listos ({orders.filter(o => o.status === 'ready').length})</TabsTrigger>
          <TabsTrigger value="delivering">En Camino ({orders.filter(o => o.status === 'delivering').length})</TabsTrigger>
        </TabsList>
      </Tabs>

      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {filteredOrders.map((order) => (
          <Card key={order.id} className="hover:shadow-lg transition-shadow">
            <CardHeader className="pb-3">
              <div className="flex justify-between items-start">
                <div>
                  <CardTitle className="text-lg mb-1">{order.orderNumber}</CardTitle>
                  <p className="text-sm text-gray-600">{order.time}</p>
                </div>
                <Badge className={getStatusColor(order.status)}>
                  {getStatusLabel(order.status)}
                </Badge>
              </div>
            </CardHeader>
            <CardContent>
              <div className="space-y-3">
                <div>
                  <p className="text-gray-900">{order.customer.name}</p>
                  <p className="text-sm text-gray-600">{order.customer.phone}</p>
                  <p className="text-sm text-gray-500 line-clamp-2">{order.customer.address}</p>
                </div>
                <div className="border-t pt-3">
                  <p className="text-sm text-gray-600 mb-2">Productos:</p>
                  {order.items.map((item, idx) => (
                    <p key={idx} className="text-sm text-gray-800">
                      {item.quantity}x {item.name}
                    </p>
                  ))}
                </div>
                <div className="border-t pt-3">
                  <div className="flex justify-between text-gray-900 mb-2">
                    <span>Total:</span>
                    <span className="text-lg">${order.total.toFixed(2)}</span>
                  </div>
                  <p className="text-xs text-gray-500">Pago: {order.paymentMethod}</p>
                </div>
                <Button
                  onClick={() => setSelectedOrder(order)}
                  variant="outline"
                  className="w-full"
                >
                  <Eye className="w-4 h-4 mr-2" />
                  Ver Detalles
                </Button>
              </div>
            </CardContent>
          </Card>
        ))}
      </div>

      <Dialog open={!!selectedOrder} onOpenChange={() => setSelectedOrder(null)}>
        <DialogContent className="max-w-2xl">
          <DialogHeader>
            <DialogTitle>Detalles del Pedido {selectedOrder?.orderNumber}</DialogTitle>
          </DialogHeader>
          {selectedOrder && (
            <div className="space-y-4">
              <div className="grid grid-cols-2 gap-4">
                <div>
                  <p className="text-sm text-gray-600">Cliente</p>
                  <p className="text-gray-900">{selectedOrder.customer.name}</p>
                  <p className="text-sm text-gray-600 mt-1">{selectedOrder.customer.phone}</p>
                </div>
                <div>
                  <p className="text-sm text-gray-600">Hora del Pedido</p>
                  <p className="text-gray-900">{selectedOrder.time}</p>
                </div>
              </div>

              <div>
                <p className="text-sm text-gray-600 mb-1">Dirección de Entrega</p>
                <p className="text-gray-900">{selectedOrder.customer.address}</p>
              </div>

              <div className="border-t pt-4">
                <p className="text-gray-900 mb-3">Productos</p>
                <div className="space-y-2">
                  {selectedOrder.items.map((item, index) => (
                    <div key={index} className="flex justify-between">
                      <span className="text-gray-600">
                        {item.quantity}x {item.name}
                      </span>
                      <span className="text-gray-900">
                        ${(item.price * item.quantity).toFixed(2)}
                      </span>
                    </div>
                  ))}
                </div>
              </div>

              <div className="border-t pt-4 space-y-2">
                <div className="flex justify-between text-gray-600">
                  <span>Subtotal</span>
                  <span>${selectedOrder.subtotal.toFixed(2)}</span>
                </div>
                <div className="flex justify-between text-gray-600">
                  <span>Envío</span>
                  <span>${selectedOrder.delivery.toFixed(2)}</span>
                </div>
                <div className="flex justify-between text-gray-900 pt-2 border-t">
                  <span>Total</span>
                  <span className="text-xl">${selectedOrder.total.toFixed(2)}</span>
                </div>
                <p className="text-sm text-gray-600">Método de Pago: {selectedOrder.paymentMethod}</p>
              </div>

              <div className="border-t pt-4">
                <p className="text-gray-900 mb-3">Actualizar Estado</p>
                <div className="grid grid-cols-2 gap-2">
                  {selectedOrder.status === 'pending' && (
                    <>
                      <Button
                        onClick={() => updateOrderStatus(selectedOrder.id, 'preparing')}
                        className="bg-yellow-600 hover:bg-yellow-700"
                      >
                        <Clock className="w-4 h-4 mr-2" />
                        Iniciar Preparación
                      </Button>
                      <Button
                        onClick={() => updateOrderStatus(selectedOrder.id, 'cancelled')}
                        variant="destructive"
                      >
                        <XCircle className="w-4 h-4 mr-2" />
                        Cancelar
                      </Button>
                    </>
                  )}
                  {selectedOrder.status === 'preparing' && (
                    <Button
                      onClick={() => updateOrderStatus(selectedOrder.id, 'ready')}
                      className="bg-green-600 hover:bg-green-700 col-span-2"
                    >
                      <CheckCircle className="w-4 h-4 mr-2" />
                      Marcar como Listo
                    </Button>
                  )}
                  {selectedOrder.status === 'ready' && (
                    <Button
                      onClick={() => updateOrderStatus(selectedOrder.id, 'delivering')}
                      className="bg-purple-600 hover:bg-purple-700 col-span-2"
                    >
                      <Truck className="w-4 h-4 mr-2" />
                      En Camino
                    </Button>
                  )}
                  {selectedOrder.status === 'delivering' && (
                    <Button
                      onClick={() => updateOrderStatus(selectedOrder.id, 'completed')}
                      className="bg-gray-600 hover:bg-gray-700 col-span-2"
                    >
                      <CheckCircle className="w-4 h-4 mr-2" />
                      Completar Entrega
                    </Button>
                  )}
                </div>
              </div>
            </div>
          )}
        </DialogContent>
      </Dialog>
    </div>
  );
}
