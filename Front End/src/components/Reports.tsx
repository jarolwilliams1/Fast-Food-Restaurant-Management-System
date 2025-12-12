import { Card, CardContent, CardHeader, CardTitle } from './ui/card';
import { BarChart, Bar, LineChart, Line, PieChart, Pie, Cell, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';
import { TrendingUp, DollarSign, ShoppingBag, Users } from 'lucide-react';

export function Reports() {
  const dailySales = [
    { day: 'Lun', ventas: 450 },
    { day: 'Mar', ventas: 520 },
    { day: 'Mié', ventas: 480 },
    { day: 'Jue', ventas: 610 },
    { day: 'Vie', ventas: 890 },
    { day: 'Sáb', ventas: 1200 },
    { day: 'Dom', ventas: 980 },
  ];

  const categoryData = [
    { name: 'Hamburguesas', value: 35 },
    { name: 'Pizzas', value: 25 },
    { name: 'Combos', value: 20 },
    { name: 'Bebidas', value: 12 },
    { name: 'Acompañamientos', value: 8 },
  ];

  const hourlyOrders = [
    { hora: '8:00', pedidos: 5 },
    { hora: '10:00', pedidos: 15 },
    { hora: '12:00', pedidos: 35 },
    { hora: '14:00', pedidos: 28 },
    { hora: '16:00', pedidos: 12 },
    { hora: '18:00', pedidos: 30 },
    { hora: '20:00', pedidos: 25 },
    { hora: '22:00', pedidos: 8 },
  ];

  const topProducts = [
    { name: 'Combo Burger', sales: 45, revenue: 719.55 },
    { name: 'Pizza Familiar', sales: 32, revenue: 735.68 },
    { name: 'Hamburguesa Doble', sales: 38, revenue: 493.62 },
    { name: 'Combo Familiar', sales: 18, revenue: 827.82 },
    { name: 'Papas Fritas', sales: 67, revenue: 267.33 },
  ];

  const COLORS = ['#f97316', '#3b82f6', '#8b5cf6', '#10b981', '#f59e0b'];

  return (
    <div className="p-8">
      <div className="mb-6">
        <h1 className="text-gray-900 mb-2">Reportes y Estadísticas</h1>
        <p className="text-gray-600">Análisis del desempeño del negocio</p>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-4 gap-6 mb-6">
        <Card>
          <CardContent className="p-6">
            <div className="flex items-center justify-between mb-2">
              <div className="w-10 h-10 bg-orange-100 rounded-full flex items-center justify-center">
                <DollarSign className="w-5 h-5 text-orange-600" />
              </div>
              <span className="text-green-600 text-sm">+15%</span>
            </div>
            <p className="text-gray-600 text-sm mb-1">Ventas Totales</p>
            <p className="text-2xl text-gray-900">$8,750.50</p>
            <p className="text-gray-500 text-xs mt-1">Esta semana</p>
          </CardContent>
        </Card>

        <Card>
          <CardContent className="p-6">
            <div className="flex items-center justify-between mb-2">
              <div className="w-10 h-10 bg-blue-100 rounded-full flex items-center justify-center">
                <ShoppingBag className="w-5 h-5 text-blue-600" />
              </div>
              <span className="text-green-600 text-sm">+8%</span>
            </div>
            <p className="text-gray-600 text-sm mb-1">Total Pedidos</p>
            <p className="text-2xl text-gray-900">342</p>
            <p className="text-gray-500 text-xs mt-1">Esta semana</p>
          </CardContent>
        </Card>

        <Card>
          <CardContent className="p-6">
            <div className="flex items-center justify-between mb-2">
              <div className="w-10 h-10 bg-purple-100 rounded-full flex items-center justify-center">
                <TrendingUp className="w-5 h-5 text-purple-600" />
              </div>
              <span className="text-green-600 text-sm">+5%</span>
            </div>
            <p className="text-gray-600 text-sm mb-1">Ticket Promedio</p>
            <p className="text-2xl text-gray-900">$25.58</p>
            <p className="text-gray-500 text-xs mt-1">Esta semana</p>
          </CardContent>
        </Card>

        <Card>
          <CardContent className="p-6">
            <div className="flex items-center justify-between mb-2">
              <div className="w-10 h-10 bg-green-100 rounded-full flex items-center justify-center">
                <Users className="w-5 h-5 text-green-600" />
              </div>
              <span className="text-green-600 text-sm">+12%</span>
            </div>
            <p className="text-gray-600 text-sm mb-1">Clientes Nuevos</p>
            <p className="text-2xl text-gray-900">48</p>
            <p className="text-gray-500 text-xs mt-1">Esta semana</p>
          </CardContent>
        </Card>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6 mb-6">
        <Card>
          <CardHeader>
            <CardTitle>Ventas por Día</CardTitle>
          </CardHeader>
          <CardContent>
            <ResponsiveContainer width="100%" height={300}>
              <LineChart data={dailySales}>
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis dataKey="day" />
                <YAxis />
                <Tooltip />
                <Legend />
                <Line type="monotone" dataKey="ventas" stroke="#f97316" strokeWidth={2} />
              </LineChart>
            </ResponsiveContainer>
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle>Ventas por Categoría</CardTitle>
          </CardHeader>
          <CardContent>
            <ResponsiveContainer width="100%" height={300}>
              <PieChart>
                <Pie
                  data={categoryData}
                  cx="50%"
                  cy="50%"
                  labelLine={false}
                  label={({ name, percent }) => `${name} ${(percent * 100).toFixed(0)}%`}
                  outerRadius={80}
                  fill="#8884d8"
                  dataKey="value"
                >
                  {categoryData.map((entry, index) => (
                    <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                  ))}
                </Pie>
                <Tooltip />
              </PieChart>
            </ResponsiveContainer>
          </CardContent>
        </Card>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        <Card>
          <CardHeader>
            <CardTitle>Pedidos por Hora</CardTitle>
          </CardHeader>
          <CardContent>
            <ResponsiveContainer width="100%" height={300}>
              <BarChart data={hourlyOrders}>
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis dataKey="hora" />
                <YAxis />
                <Tooltip />
                <Legend />
                <Bar dataKey="pedidos" fill="#3b82f6" />
              </BarChart>
            </ResponsiveContainer>
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle>Productos Más Vendidos</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="space-y-4">
              {topProducts.map((product, index) => (
                <div key={index} className="flex items-center justify-between">
                  <div className="flex-1">
                    <div className="flex items-center gap-3">
                      <div className="w-8 h-8 bg-orange-100 rounded-full flex items-center justify-center text-orange-600">
                        {index + 1}
                      </div>
                      <div className="flex-1">
                        <p className="text-gray-900">{product.name}</p>
                        <p className="text-gray-500 text-sm">{product.sales} ventas</p>
                      </div>
                    </div>
                  </div>
                  <div className="text-right">
                    <p className="text-gray-900">${product.revenue.toFixed(2)}</p>
                  </div>
                </div>
              ))}
            </div>
          </CardContent>
        </Card>
      </div>
    </div>
  );
}
