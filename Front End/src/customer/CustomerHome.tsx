import { Clock, Truck, Tag, Star } from 'lucide-react';
import { CustomerViewType } from './CustomerApp';
import { Card, CardContent } from '../components/ui/card';
import { Button } from '../components/ui/button';

interface CustomerHomeProps {
  onNavigate: (view: CustomerViewType) => void;
}

export function CustomerHome({ onNavigate }: CustomerHomeProps) {
  const features = [
    { icon: Clock, title: 'Entrega Rápida', description: 'Pedidos en 30-45 minutos' },
    { icon: Truck, title: 'Envío Gratis', description: 'En pedidos mayores a $25' },
    { icon: Tag, title: 'Promociones', description: 'Descuentos especiales' },
    { icon: Star, title: 'Calidad Garantizada', description: 'Ingredientes frescos' },
  ];

  const popularItems = [
    { name: 'Combo Burger', price: 15.99, image: '🍔' },
    { name: 'Pizza Familiar', price: 22.99, image: '🍕' },
    { name: 'Hamburguesa Doble', price: 12.99, image: '🍔' },
  ];

  return (
    <div>
      {/* Hero Section */}
      <section className="bg-gradient-to-r from-orange-600 to-orange-500 text-white py-20">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="max-w-3xl">
            <h1 className="text-white mb-4">
              Comida Rápida a tu Puerta
            </h1>
            <p className="text-xl text-orange-100 mb-8">
              Ordena tus platillos favoritos y recíbelos en la comodidad de tu hogar
            </p>
            <Button
              onClick={() => onNavigate('menu')}
              size="lg"
              className="bg-white text-orange-600 hover:bg-orange-50 px-8"
            >
              Ver Menú Completo
            </Button>
          </div>
        </div>
      </section>

      {/* Features */}
      <section className="py-16 bg-white">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8">
            {features.map((feature, index) => {
              const Icon = feature.icon;
              return (
                <div key={index} className="text-center">
                  <div className="w-16 h-16 bg-orange-100 rounded-full flex items-center justify-center mx-auto mb-4">
                    <Icon className="w-8 h-8 text-orange-600" />
                  </div>
                  <h3 className="text-gray-900 mb-2">{feature.title}</h3>
                  <p className="text-gray-600">{feature.description}</p>
                </div>
              );
            })}
          </div>
        </div>
      </section>

      {/* Popular Items */}
      <section className="py-16 bg-gray-50">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="text-center mb-12">
            <h2 className="text-gray-900 mb-2">Más Populares</h2>
            <p className="text-gray-600">Los favoritos de nuestros clientes</p>
          </div>
          <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
            {popularItems.map((item, index) => (
              <Card key={index} className="hover:shadow-lg transition-shadow">
                <CardContent className="p-6">
                  <div className="text-6xl text-center mb-4">{item.image}</div>
                  <h3 className="text-gray-900 text-center mb-2">{item.name}</h3>
                  <p className="text-orange-600 text-center text-xl mb-4">
                    ${item.price.toFixed(2)}
                  </p>
                  <Button
                    onClick={() => onNavigate('menu')}
                    className="w-full bg-orange-600 hover:bg-orange-700"
                  >
                    Ordenar Ahora
                  </Button>
                </CardContent>
              </Card>
            ))}
          </div>
        </div>
      </section>

      {/* CTA Section */}
      <section className="py-16 bg-orange-600 text-white">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 text-center">
          <h2 className="text-white mb-4">¿Listo para ordenar?</h2>
          <p className="text-xl text-orange-100 mb-8">
            Explora nuestro menú completo y recibe tu comida en minutos
          </p>
          <Button
            onClick={() => onNavigate('menu')}
            size="lg"
            className="bg-white text-orange-600 hover:bg-orange-50 px-8"
          >
            Explorar Menú
          </Button>
        </div>
      </section>
    </div>
  );
}
