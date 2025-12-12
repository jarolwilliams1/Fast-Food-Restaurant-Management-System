import { useState, useEffect } from 'react';
import { CheckCircle, Clock, Package, Truck } from 'lucide-react';
import { CustomerViewType } from './CustomerApp';
import { Card, CardContent, CardHeader, CardTitle } from '../components/ui/card';
import { Button } from '../components/ui/button';

interface CustomerOrderTrackingProps {
  orderId: string | null;
  onNavigate: (view: CustomerViewType) => void;
}

export function CustomerOrderTracking({ orderId, onNavigate }: CustomerOrderTrackingProps) {
  const [currentStatus, setCurrentStatus] = useState(0);

  const statuses = [
    { id: 0, label: 'Pedido Recibido', icon: CheckCircle, description: 'Tu pedido ha sido confirmado' },
    { id: 1, label: 'Preparando', icon: Clock, description: 'El restaurante está preparando tu orden' },
    { id: 2, label: 'Listo para Entrega', icon: Package, description: 'Tu pedido está listo' },
    { id: 3, label: 'En Camino', icon: Truck, description: 'El repartidor va hacia tu dirección' },
    { id: 4, label: 'Entregado', icon: CheckCircle, description: '¡Disfruta tu comida!' },
  ];

  // Simular progreso del pedido
  useEffect(() => {
    const interval = setInterval(() => {
      setCurrentStatus((prev) => {
        if (prev < statuses.length - 1) {
          return prev + 1;
        }
        clearInterval(interval);
        return prev;
      });
    }, 5000); // Cambia de estado cada 5 segundos

    return () => clearInterval(interval);
  }, []);

  if (!orderId) {
    return (
      <div className="max-w-4xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
        <Card>
          <CardContent className="py-16 text-center">
            <Package className="w-16 h-16 text-gray-300 mx-auto mb-4" />
            <h2 className="text-gray-900 mb-2">No hay pedido en seguimiento</h2>
            <p className="text-gray-600 mb-6">Realiza un pedido para ver su estado</p>
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
        <h1 className="text-gray-900 mb-2">Seguimiento de Pedido</h1>
        <p className="text-gray-600">Pedido {orderId}</p>
      </div>

      <Card className="mb-6">
        <CardHeader>
          <CardTitle>Estado Actual</CardTitle>
        </CardHeader>
        <CardContent>
          <div className="space-y-6">
            {statuses.map((status, index) => {
              const Icon = status.icon;
              const isCompleted = index <= currentStatus;
              const isCurrent = index === currentStatus;

              return (
                <div key={status.id} className="flex gap-4">
                  <div className="flex flex-col items-center">
                    <div
                      className={`w-12 h-12 rounded-full flex items-center justify-center transition-colors ${
                        isCompleted
                          ? 'bg-green-600 text-white'
                          : 'bg-gray-200 text-gray-400'
                      }`}
                    >
                      <Icon className="w-6 h-6" />
                    </div>
                    {index < statuses.length - 1 && (
                      <div
                        className={`w-0.5 h-16 ${
                          isCompleted ? 'bg-green-600' : 'bg-gray-200'
                        }`}
                      />
                    )}
                  </div>
                  <div className="flex-1 pb-8">
                    <h3
                      className={`mb-1 ${
                        isCompleted ? 'text-gray-900' : 'text-gray-500'
                      }`}
                    >
                      {status.label}
                    </h3>
                    <p
                      className={`text-sm ${
                        isCurrent ? 'text-orange-600' : 'text-gray-500'
                      }`}
                    >
                      {status.description}
                    </p>
                    {isCurrent && (
                      <div className="mt-2">
                        <div className="flex items-center gap-2 text-orange-600">
                          <div className="w-2 h-2 bg-orange-600 rounded-full animate-pulse" />
                          <span className="text-sm">En progreso...</span>
                        </div>
                      </div>
                    )}
                  </div>
                </div>
              );
            })}
          </div>
        </CardContent>
      </Card>

      <Card>
        <CardHeader>
          <CardTitle>Información del Pedido</CardTitle>
        </CardHeader>
        <CardContent>
          <div className="space-y-3">
            <div className="flex justify-between">
              <span className="text-gray-600">Número de Pedido</span>
              <span className="text-gray-900">{orderId}</span>
            </div>
            <div className="flex justify-between">
              <span className="text-gray-600">Tiempo Estimado</span>
              <span className="text-gray-900">30-45 minutos</span>
            </div>
            <div className="flex justify-between">
              <span className="text-gray-600">Estado</span>
              <span className="text-orange-600">{statuses[currentStatus].label}</span>
            </div>
          </div>
        </CardContent>
      </Card>

      <div className="mt-6 text-center">
        <Button
          onClick={() => onNavigate('home')}
          variant="outline"
        >
          Volver al Inicio
        </Button>
      </div>
    </div>
  );
}
