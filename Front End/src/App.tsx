import { useState } from 'react';
import { AdminApp } from './admin/AdminApp';
import { CustomerApp } from './customer/CustomerApp';
import { Button } from './components/ui/button';
import { Monitor, Globe } from 'lucide-react';

type AppMode = 'selector' | 'admin' | 'customer';

export default function App() {
  const [mode, setMode] = useState<AppMode>('selector');

  if (mode === 'admin') {
    return (
      <div>
        <div className="fixed top-4 right-4 z-50">
          <Button
            onClick={() => setMode('selector')}
            variant="outline"
            className="bg-white"
          >
            Cambiar Vista
          </Button>
        </div>
        <AdminApp />
      </div>
    );
  }

  if (mode === 'customer') {
    return (
      <div>
        <div className="fixed top-4 right-4 z-50">
          <Button
            onClick={() => setMode('selector')}
            variant="outline"
            className="bg-white shadow-lg"
          >
            Cambiar Vista
          </Button>
        </div>
        <CustomerApp />
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-gradient-to-br from-orange-50 to-orange-100 flex items-center justify-center p-8">
      <div className="max-w-4xl w-full">
        <div className="text-center mb-12">
          <h1 className="text-gray-900 mb-2">Sistema de Gestión FastFood</h1>
          <p className="text-gray-600">Selecciona la vista que deseas utilizar</p>
        </div>

        <div className="grid md:grid-cols-2 gap-8">
          <button
            onClick={() => setMode('admin')}
            className="bg-white rounded-xl p-8 shadow-lg hover:shadow-xl transition-all hover:scale-105 text-left"
          >
            <div className="w-16 h-16 bg-orange-100 rounded-full flex items-center justify-center mb-6">
              <Monitor className="w-8 h-8 text-orange-600" />
            </div>
            <h2 className="text-gray-900 mb-3">Aplicación de Escritorio</h2>
            <p className="text-gray-600 mb-4">
              Panel administrativo para gestionar pedidos online y locales, menú, promociones y reportes.
            </p>
            <ul className="space-y-2 text-sm text-gray-600">
              <li className="flex items-center gap-2">
                <div className="w-1.5 h-1.5 bg-orange-600 rounded-full"></div>
                Gestión de pedidos online
              </li>
              <li className="flex items-center gap-2">
                <div className="w-1.5 h-1.5 bg-orange-600 rounded-full"></div>
                Tomar pedidos en local (POS)
              </li>
              <li className="flex items-center gap-2">
                <div className="w-1.5 h-1.5 bg-orange-600 rounded-full"></div>
                Administrar menú y promociones
              </li>
              <li className="flex items-center gap-2">
                <div className="w-1.5 h-1.5 bg-orange-600 rounded-full"></div>
                Reportes y estadísticas
              </li>
            </ul>
          </button>

          <button
            onClick={() => setMode('customer')}
            className="bg-white rounded-xl p-8 shadow-lg hover:shadow-xl transition-all hover:scale-105 text-left"
          >
            <div className="w-16 h-16 bg-blue-100 rounded-full flex items-center justify-center mb-6">
              <Globe className="w-8 h-8 text-blue-600" />
            </div>
            <h2 className="text-gray-900 mb-3">Página Web Cliente</h2>
            <p className="text-gray-600 mb-4">
              Sitio web para que los clientes realicen pedidos a domicilio de forma rápida y sencilla.
            </p>
            <ul className="space-y-2 text-sm text-gray-600">
              <li className="flex items-center gap-2">
                <div className="w-1.5 h-1.5 bg-blue-600 rounded-full"></div>
                Ver menú disponible
              </li>
              <li className="flex items-center gap-2">
                <div className="w-1.5 h-1.5 bg-blue-600 rounded-full"></div>
                Realizar pedidos a domicilio
              </li>
              <li className="flex items-center gap-2">
                <div className="w-1.5 h-1.5 bg-blue-600 rounded-full"></div>
                Aplicar promociones
              </li>
              <li className="flex items-center gap-2">
                <div className="w-1.5 h-1.5 bg-blue-600 rounded-full"></div>
                Seguimiento de pedidos
              </li>
            </ul>
          </button>
        </div>
      </div>
    </div>
  );
}
