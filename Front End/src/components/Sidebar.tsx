import { LayoutDashboard, UtensilsCrossed, ShoppingCart, Tag, Receipt, BarChart3 } from 'lucide-react';
import { ViewType } from '../App';

interface SidebarProps {
  currentView: ViewType;
  onNavigate: (view: ViewType) => void;
}

export function Sidebar({ currentView, onNavigate }: SidebarProps) {
  const menuItems = [
    { id: 'dashboard' as ViewType, icon: LayoutDashboard, label: 'Dashboard' },
    { id: 'orders' as ViewType, icon: ShoppingCart, label: 'Tomar Pedido' },
    { id: 'menu' as ViewType, icon: UtensilsCrossed, label: 'Gestión Menú' },
    { id: 'promotions' as ViewType, icon: Tag, label: 'Promociones' },
    { id: 'sales' as ViewType, icon: Receipt, label: 'Historial Ventas' },
    { id: 'reports' as ViewType, icon: BarChart3, label: 'Reportes' },
  ];

  return (
    <aside className="w-64 bg-white border-r border-gray-200 flex flex-col">
      <div className="p-6 border-b border-gray-200">
        <h1 className="text-orange-600">FastFood Manager</h1>
      </div>
      <nav className="flex-1 p-4">
        {menuItems.map((item) => {
          const Icon = item.icon;
          const isActive = currentView === item.id;
          return (
            <button
              key={item.id}
              onClick={() => onNavigate(item.id)}
              className={`w-full flex items-center gap-3 px-4 py-3 rounded-lg mb-2 transition-colors ${
                isActive
                  ? 'bg-orange-100 text-orange-600'
                  : 'text-gray-600 hover:bg-gray-100'
              }`}
            >
              <Icon className="w-5 h-5" />
              <span>{item.label}</span>
            </button>
          );
        })}
      </nav>
    </aside>
  );
}
