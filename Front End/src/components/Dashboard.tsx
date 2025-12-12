import { DollarSign, ShoppingBag, TrendingUp, Users } from 'lucide-react';
import { Card, CardContent, CardHeader, CardTitle } from './ui/card';
import { ViewType } from '../App';

interface DashboardProps {
  onNavigate: (view: ViewType) => void;
}

export function Dashboard({ onNavigate }: DashboardProps) {
  const stats = [
    {
      title: 'Ventas Hoy',
      value: '$1,245.50',
      icon: DollarSign,
      change: '+12.5%',
      trend: 'up' as const,
    },
    {
      title: 'Pedidos Hoy',
      value: '48',
      icon: ShoppingBag,
      change: '+8.2%',
      trend: 'up' as const,
    },
    {
      title: 'Ticket Promedio',
      value: '$25.95',
      icon: TrendingUp,
      change: '+3.1%',
      trend: 'up' as const,
    },
    {
      title: 'Clientes Nuevos',
      value: '12',
      icon: Users,
      change: '+5.4%',
      trend: 'up' as const,
    },
  ];

  const recentOrders = [
    { id: '#001', time: '10:45', items: 'Combo Burger + Papas', total: '$15.99', status: 'Completado' },
    { id: '#002', time: '10:52', items: 'Pizza Personal + Refresco', total: '$12.50', status: 'En Preparación' },
    { id: '#003', time: '11:03', items: '2x Hamburguesa Doble', total: '$24.98', status: 'Completado' },
    { id: '#004', time: '11:15', items: 'Combo Familiar', total: '$45.99', status: 'Pendiente' },
  ];

  return (
    <div className="p-8">
      <div className="mb-8">
        <h1 className="text-gray-900 mb-2">Dashboard</h1>
        <p className="text-gray-600">Resumen de operaciones del día</p>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6 mb-8">
        {stats.map((stat) => {
          const Icon = stat.icon;
          return (
            <Card key={stat.title}>
              <CardHeader className="flex flex-row items-center justify-between pb-2">
                <CardTitle className="text-sm text-gray-600">{stat.title}</CardTitle>
                <div className="w-8 h-8 bg-orange-100 rounded-full flex items-center justify-center">
                  <Icon className="w-4 h-4 text-orange-600" />
                </div>
              </CardHeader>
              <CardContent>
                <div className="text-2xl text-gray-900 mb-1">{stat.value}</div>
                <p className="text-sm text-green-600">{stat.change} vs ayer</p>
              </CardContent>
            </Card>
          );
        })}
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        <Card>
          <CardHeader>
            <CardTitle>Pedidos Recientes</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="space-y-4">
              {recentOrders.map((order) => (
                <div key={order.id} className="flex items-center justify-between border-b border-gray-100 pb-4 last:border-0 last:pb-0">
                  <div>
                    <div className="flex items-center gap-2">
                      <span className="text-gray-900">{order.id}</span>
                      <span className="text-gray-500 text-sm">{order.time}</span>
                    </div>
                    <p className="text-gray-600 text-sm mt-1">{order.items}</p>
                  </div>
                  <div className="text-right">
                    <div className="text-gray-900 mb-1">{order.total}</div>
                    <span className={`text-xs px-2 py-1 rounded-full ${
                      order.status === 'Completado' ? 'bg-green-100 text-green-700' :
                      order.status === 'En Preparación' ? 'bg-yellow-100 text-yellow-700' :
                      'bg-gray-100 text-gray-700'
                    }`}>
                      {order.status}
                    </span>
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
                onClick={() => onNavigate('orders')}
                className="p-4 bg-orange-600 text-white rounded-lg hover:bg-orange-700 transition-colors"
              >
                <ShoppingBag className="w-6 h-6 mb-2" />
                <span>Nuevo Pedido</span>
              </button>
              <button
                onClick={() => onNavigate('menu')}
                className="p-4 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition-colors"
              >
                <Users className="w-6 h-6 mb-2" />
                <span>Gestionar Menú</span>
              </button>
              <button
                onClick={() => onNavigate('promotions')}
                className="p-4 bg-purple-600 text-white rounded-lg hover:bg-purple-700 transition-colors"
              >
                <TrendingUp className="w-6 h-6 mb-2" />
                <span>Promociones</span>
              </button>
              <button
                onClick={() => onNavigate('reports')}
                className="p-4 bg-green-600 text-white rounded-lg hover:bg-green-700 transition-colors"
              >
                <DollarSign className="w-6 h-6 mb-2" />
                <span>Ver Reportes</span>
              </button>
            </div>
          </CardContent>
        </Card>
      </div>
    </div>
  );
}
