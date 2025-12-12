import { useState } from 'react';
import { Calendar, DollarSign, Eye, Filter } from 'lucide-react';
import { Card, CardContent, CardHeader, CardTitle } from './ui/card';
import { Button } from './ui/button';
import { Badge } from './ui/badge';
import { Dialog, DialogContent, DialogHeader, DialogTitle } from './ui/dialog';
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select';

interface Sale {
  id: string;
  orderNumber: string;
  date: string;
  time: string;
  customer: string;
  items: { name: string; quantity: number; price: number }[];
  subtotal: number;
  discount: number;
  total: number;
  paymentMethod: string;
  status: 'completed' | 'cancelled';
}

export function SalesHistory() {
  const [sales] = useState<Sale[]>([
    {
      id: '1',
      orderNumber: '#001',
      date: '2025-11-21',
      time: '10:45',
      customer: 'Juan Pérez',
      items: [
        { name: 'Combo Burger', quantity: 1, price: 15.99 },
        { name: 'Papas Fritas', quantity: 1, price: 3.99 },
      ],
      subtotal: 19.98,
      discount: 0,
      total: 19.98,
      paymentMethod: 'Tarjeta',
      status: 'completed',
    },
    {
      id: '2',
      orderNumber: '#002',
      date: '2025-11-21',
      time: '10:52',
      customer: 'María García',
      items: [
        { name: 'Pizza Personal', quantity: 1, price: 10.50 },
        { name: 'Refresco', quantity: 1, price: 2.50 },
      ],
      subtotal: 13.00,
      discount: 1.30,
      total: 11.70,
      paymentMethod: 'Efectivo',
      status: 'completed',
    },
    {
      id: '3',
      orderNumber: '#003',
      date: '2025-11-21',
      time: '11:03',
      customer: 'Cliente General',
      items: [
        { name: 'Hamburguesa Doble', quantity: 2, price: 12.99 },
      ],
      subtotal: 25.98,
      discount: 0,
      total: 25.98,
      paymentMethod: 'Tarjeta',
      status: 'completed',
    },
    {
      id: '4',
      orderNumber: '#004',
      date: '2025-11-21',
      time: '11:15',
      customer: 'Pedro López',
      items: [
        { name: 'Combo Familiar', quantity: 1, price: 45.99 },
      ],
      subtotal: 45.99,
      discount: 5.00,
      total: 40.99,
      paymentMethod: 'Efectivo',
      status: 'completed',
    },
    {
      id: '5',
      orderNumber: '#005',
      date: '2025-11-21',
      time: '11:25',
      customer: 'Ana Martínez',
      items: [
        { name: 'Pizza Personal', quantity: 1, price: 10.50 },
      ],
      subtotal: 10.50,
      discount: 0,
      total: 10.50,
      paymentMethod: 'Tarjeta',
      status: 'cancelled',
    },
  ]);

  const [selectedSale, setSelectedSale] = useState<Sale | null>(null);
  const [filterStatus, setFilterStatus] = useState<string>('all');

  const filteredSales = filterStatus === 'all'
    ? sales
    : sales.filter(sale => sale.status === filterStatus);

  const totalSales = sales.filter(s => s.status === 'completed').reduce((sum, sale) => sum + sale.total, 0);
  const completedSales = sales.filter(s => s.status === 'completed').length;

  return (
    <div className="p-8">
      <div className="mb-6">
        <h1 className="text-gray-900 mb-2">Historial de Ventas</h1>
        <p className="text-gray-600">Revisa todas las transacciones realizadas</p>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mb-6">
        <Card>
          <CardContent className="p-6">
            <div className="flex items-center justify-between">
              <div>
                <p className="text-gray-600 mb-1">Total Ventas Hoy</p>
                <p className="text-2xl text-gray-900">${totalSales.toFixed(2)}</p>
              </div>
              <div className="w-12 h-12 bg-green-100 rounded-full flex items-center justify-center">
                <DollarSign className="w-6 h-6 text-green-600" />
              </div>
            </div>
          </CardContent>
        </Card>

        <Card>
          <CardContent className="p-6">
            <div className="flex items-center justify-between">
              <div>
                <p className="text-gray-600 mb-1">Pedidos Completados</p>
                <p className="text-2xl text-gray-900">{completedSales}</p>
              </div>
              <div className="w-12 h-12 bg-blue-100 rounded-full flex items-center justify-center">
                <Calendar className="w-6 h-6 text-blue-600" />
              </div>
            </div>
          </CardContent>
        </Card>

        <Card>
          <CardContent className="p-6">
            <div className="flex items-center justify-between">
              <div>
                <p className="text-gray-600 mb-1">Ticket Promedio</p>
                <p className="text-2xl text-gray-900">
                  ${completedSales > 0 ? (totalSales / completedSales).toFixed(2) : '0.00'}
                </p>
              </div>
              <div className="w-12 h-12 bg-purple-100 rounded-full flex items-center justify-center">
                <DollarSign className="w-6 h-6 text-purple-600" />
              </div>
            </div>
          </CardContent>
        </Card>
      </div>

      <Card>
        <CardHeader>
          <div className="flex justify-between items-center">
            <CardTitle>Transacciones</CardTitle>
            <div className="flex items-center gap-2">
              <Filter className="w-4 h-4 text-gray-400" />
              <Select value={filterStatus} onValueChange={setFilterStatus}>
                <SelectTrigger className="w-[180px]">
                  <SelectValue />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="all">Todas</SelectItem>
                  <SelectItem value="completed">Completadas</SelectItem>
                  <SelectItem value="cancelled">Canceladas</SelectItem>
                </SelectContent>
              </Select>
            </div>
          </div>
        </CardHeader>
        <CardContent className="p-0">
          <div className="overflow-x-auto">
            <table className="w-full">
              <thead className="bg-gray-50 border-b">
                <tr>
                  <th className="text-left p-4 text-gray-600">Pedido</th>
                  <th className="text-left p-4 text-gray-600">Fecha/Hora</th>
                  <th className="text-left p-4 text-gray-600">Cliente</th>
                  <th className="text-left p-4 text-gray-600">Total</th>
                  <th className="text-left p-4 text-gray-600">Método Pago</th>
                  <th className="text-left p-4 text-gray-600">Estado</th>
                  <th className="text-right p-4 text-gray-600">Acciones</th>
                </tr>
              </thead>
              <tbody>
                {filteredSales.map((sale) => (
                  <tr key={sale.id} className="border-b last:border-0 hover:bg-gray-50">
                    <td className="p-4">
                      <span className="text-gray-900">{sale.orderNumber}</span>
                    </td>
                    <td className="p-4">
                      <div className="text-gray-900">{sale.date}</div>
                      <div className="text-gray-500 text-sm">{sale.time}</div>
                    </td>
                    <td className="p-4">
                      <span className="text-gray-900">{sale.customer}</span>
                    </td>
                    <td className="p-4">
                      <div className="text-gray-900">${sale.total.toFixed(2)}</div>
                      {sale.discount > 0 && (
                        <div className="text-green-600 text-sm">-${sale.discount.toFixed(2)}</div>
                      )}
                    </td>
                    <td className="p-4">
                      <span className="text-gray-600">{sale.paymentMethod}</span>
                    </td>
                    <td className="p-4">
                      <Badge
                        variant={sale.status === 'completed' ? 'default' : 'secondary'}
                        className={
                          sale.status === 'completed'
                            ? 'bg-green-100 text-green-700'
                            : 'bg-red-100 text-red-700'
                        }
                      >
                        {sale.status === 'completed' ? 'Completado' : 'Cancelado'}
                      </Badge>
                    </td>
                    <td className="p-4">
                      <div className="flex justify-end">
                        <Button
                          variant="ghost"
                          size="sm"
                          onClick={() => setSelectedSale(sale)}
                        >
                          <Eye className="w-4 h-4" />
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

      <Dialog open={!!selectedSale} onOpenChange={() => setSelectedSale(null)}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Detalle de Venta {selectedSale?.orderNumber}</DialogTitle>
          </DialogHeader>
          {selectedSale && (
            <div className="space-y-4">
              <div className="grid grid-cols-2 gap-4">
                <div>
                  <p className="text-gray-600 text-sm">Fecha</p>
                  <p className="text-gray-900">{selectedSale.date}</p>
                </div>
                <div>
                  <p className="text-gray-600 text-sm">Hora</p>
                  <p className="text-gray-900">{selectedSale.time}</p>
                </div>
                <div>
                  <p className="text-gray-600 text-sm">Cliente</p>
                  <p className="text-gray-900">{selectedSale.customer}</p>
                </div>
                <div>
                  <p className="text-gray-600 text-sm">Método de Pago</p>
                  <p className="text-gray-900">{selectedSale.paymentMethod}</p>
                </div>
              </div>

              <div className="border-t pt-4">
                <p className="text-gray-900 mb-3">Productos</p>
                <div className="space-y-2">
                  {selectedSale.items.map((item, index) => (
                    <div key={index} className="flex justify-between text-sm">
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
                <div className="flex justify-between">
                  <span className="text-gray-600">Subtotal</span>
                  <span className="text-gray-900">${selectedSale.subtotal.toFixed(2)}</span>
                </div>
                {selectedSale.discount > 0 && (
                  <div className="flex justify-between text-green-600">
                    <span>Descuento</span>
                    <span>-${selectedSale.discount.toFixed(2)}</span>
                  </div>
                )}
                <div className="flex justify-between text-gray-900 pt-2 border-t">
                  <span>Total</span>
                  <span className="text-xl">${selectedSale.total.toFixed(2)}</span>
                </div>
              </div>
            </div>
          )}
        </DialogContent>
      </Dialog>
    </div>
  );
}
