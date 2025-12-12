import { ShoppingCart, Home, UtensilsCrossed, Package } from 'lucide-react';
import { CustomerViewType } from './CustomerApp';
import { Badge } from '../components/ui/badge';

interface CustomerHeaderProps {
  currentView: CustomerViewType;
  onNavigate: (view: CustomerViewType) => void;
  cartItemCount: number;
}

export function CustomerHeader({ currentView, onNavigate, cartItemCount }: CustomerHeaderProps) {
  return (
    <header className="bg-white border-b border-gray-200 sticky top-0 z-40">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between items-center h-16">
          <div className="flex items-center gap-8">
            <button onClick={() => onNavigate('home')} className="flex items-center gap-2">
              <div className="w-10 h-10 bg-orange-600 rounded-full flex items-center justify-center">
                <UtensilsCrossed className="w-6 h-6 text-white" />
              </div>
              <span className="text-xl text-gray-900">FastFood Express</span>
            </button>
            
            <nav className="hidden md:flex items-center gap-6">
              <button
                onClick={() => onNavigate('home')}
                className={`flex items-center gap-2 px-3 py-2 rounded-lg transition-colors ${
                  currentView === 'home'
                    ? 'text-orange-600 bg-orange-50'
                    : 'text-gray-600 hover:text-gray-900'
                }`}
              >
                <Home className="w-4 h-4" />
                Inicio
              </button>
              <button
                onClick={() => onNavigate('menu')}
                className={`flex items-center gap-2 px-3 py-2 rounded-lg transition-colors ${
                  currentView === 'menu'
                    ? 'text-orange-600 bg-orange-50'
                    : 'text-gray-600 hover:text-gray-900'
                }`}
              >
                <UtensilsCrossed className="w-4 h-4" />
                Menú
              </button>
              {currentView === 'tracking' && (
                <button
                  onClick={() => onNavigate('tracking')}
                  className="flex items-center gap-2 px-3 py-2 rounded-lg text-orange-600 bg-orange-50"
                >
                  <Package className="w-4 h-4" />
                  Mi Pedido
                </button>
              )}
            </nav>
          </div>

          <button
            onClick={() => onNavigate('cart')}
            className="relative flex items-center gap-2 px-4 py-2 bg-orange-600 text-white rounded-lg hover:bg-orange-700 transition-colors"
          >
            <ShoppingCart className="w-5 h-5" />
            <span className="hidden sm:inline">Carrito</span>
            {cartItemCount > 0 && (
              <Badge className="absolute -top-2 -right-2 bg-red-500 text-white px-2 min-w-[1.5rem] h-6 flex items-center justify-center">
                {cartItemCount}
              </Badge>
            )}
          </button>
        </div>
      </div>
    </header>
  );
}
