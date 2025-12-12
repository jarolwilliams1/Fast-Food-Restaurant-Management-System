import { ShoppingBag, Store, DollarSign, Clock, UtensilsCrossed, BarChart3 } from 'lucide-react';
import { Card, CardContent, CardHeader, CardTitle } from '../components/ui/card';
import { AdminViewType } from './AdminApp';
import { Badge } from '../components/ui/badge';

interface AdminDashboardProps {
  onNavigate: (view: AdminViewType) => void;
}

export function AdminDashboard({ onNavigate }: AdminDashboardProps) {
  const stats = [
    { title: 'Pedidos Online Pendientes', value: '8', icon: ShoppingBag, color: 'bg-blue-100 text-blue-600' },
    { title: 'Pedidos Locales Hoy', value: '23', icon: Store, color: 'bg-green-100 text-green-600' },
    { title: 'Ventas Totales Hoy', value: '$1,847.50', icon: DollarSign, color: 'bg-orange-100 text-orange-600' },
    { title: 'Tiempo Promedio Entrega', value: '28 min', icon: Clock, color: 'bg-purple-100 text-purple-600' },
  ];

  const onlineOrders = [
    { id: '#WEB-045', time: '11:30', customer: 'María García', items: 'Combo Burger + Papas', total: '$15.99', status: 'pending' },
    { id: '#WEB-046', time: '11:42', customer: 'Juan Pérez', items: 'Pizza Familiar + 2 Refrescos', total: '$28.99', status: 'preparing' },
    { id: '#WEB-047', time: '11:55', customer: 'Ana López', items: '2x Hamburguesa Doble', total: '$25.98', status: 'pending' },
    { id: '#WEB-048', time: '12:03', customer: 'Carlos Ruiz', items: 'Combo Familiar', total: '$45.99', status: 'ready' },
  ];

  return (
    <div className="p-8">
      <div className="mb-8">
        <h1 className="text-gray-900 mb-2">Panel de Control</h1>
        <p className="text-gray-600">Resumen general de operaciones</p>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6 mb-8">
        {stats.map((stat) => {
          const Icon = stat.icon;
          return (
            <Card key={stat.title}>
              <CardHeader className="flex flex-row items-center justify-between pb-2">
                <CardTitle className="text-sm text-gray-600">{stat.title}</CardTitle>
                <div className={`w-8 h-8 rounded-full flex items-center justify-center ${stat.color}`}>
                  <Icon className="w-4 h-4" />
                </div>
              </CardHeader>
              <CardContent>
                <div className="text-2xl text-gray-900">{stat.value}</div>
              </CardContent>
            </Card>
          );
        })}
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        <Card>
          <CardHeader>
            <div className="flex justify-between items-center">
              <CardTitle>Pedidos Online Recientes</CardTitle>
              <button
                onClick={() => onNavigate('online-orders')}
                className="text-orange-600 text-sm hover:underline"
              >
                Ver todos
              </button>
            </div>
          </CardHeader>
          <CardContent>
            <div className="space-y-4">
              {onlineOrders.map((order) => (
                <div key={order.id} className="border-b border-gray-100 pb-4 last:border-0 last:pb-0">
                  <div className="flex justify-between items-start mb-2">
                    <div>
                      <div className="flex items-center gap-2 mb-1">
                        <span className="text-gray-900">{order.id}</span>
                        <Badge
                          className={
                            order.status === 'ready' ? 'bg-green-100 text-green-700' :
                            order.status === 'preparing' ? 'bg-yellow-100 text-yellow-700' :
                            'bg-blue-100 text-blue-700'
                          }
                        >
                          {order.status === 'ready' ? 'Listo' :
                           order.status === 'preparing' ? 'Preparando' :
                           'Pendiente'}
                        </Badge>
                      </div>
                      <p className="text-sm text-gray-600">{order.customer}</p>
                      <p className="text-sm text-gray-500">{order.items}</p>
                    </div>
                    <div className="text-right">
                      <div className="text-gray-900 mb-1">{order.total}</div>
                      <div className="text-xs text-gray-500">{order.time}</div>
                    </div>
                  </div>
                </div>
              ))}
            </div>
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle>Acciones Rápidas</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="grid grid-cols-2 gap-4">
              <button
                onClick={() => onNavigate('online-orders')}
                className="p-6 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition-colors flex flex-col items-center gap-2"
              >
                <ShoppingBag className="w-8 h-8" />
                <span className="text-center">Gestionar Pedidos Online</span>
              </button>
              <button
                onClick={() => onNavigate('local-pos')}
                className="p-6 bg-green-600 text-white rounded-lg hover:bg-green-700 transition-colors flex flex-col items-center gap-2"
              >
                <Store className="w-8 h-8" />
                <span className="text-center">Pedido Local</span>
              </button>
              <button
                onClick={() => onNavigate('menu')}
                className="p-6 bg-purple-600 text-white rounded-lg hover:bg-purple-700 transition-colors flex flex-col items-center gap-2"
              >
                <UtensilsCrossed className="w-8 h-8" />
                <span className="text-center">Editar Menú</span>
              </button>
              <button
                onClick={() => onNavigate('reports')}
                className="p-6 bg-orange-600 text-white rounded-lg hover:bg-orange-700 transition-colors flex flex-col items-center gap-2"
              >
                <BarChart3 className="w-8 h-8" />
                <span className="text-center">Ver Reportes</span>
              </button>
            </div>
          </CardContent>
        </Card>
      </div>
    </div>
  );
}