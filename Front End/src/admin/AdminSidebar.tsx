import { LayoutDashboard, ShoppingBag, UtensilsCrossed, Store, Tag, BarChart3 } from 'lucide-react';
import { AdminViewType } from './AdminApp';

interface AdminSidebarProps {
  currentView: AdminViewType;
  onNavigate: (view: AdminViewType) => void;
}

export function AdminSidebar({ currentView, onNavigate }: AdminSidebarProps) {
  const menuItems = [
    { id: 'dashboard' as AdminViewType, icon: LayoutDashboard, label: 'Dashboard' },
    { id: 'online-orders' as AdminViewType, icon: ShoppingBag, label: 'Pedidos Online' },
    { id: 'local-pos' as AdminViewType, icon: Store, label: 'POS Local' },
    { id: 'menu' as AdminViewType, icon: UtensilsCrossed, label: 'Gestión Menú' },
    { id: 'promotions' as AdminViewType, icon: Tag, label: 'Promociones' },
    { id: 'reports' as AdminViewType, icon: BarChart3, label: 'Reportes' },
  ];

  return (
    <aside className="w-64 bg-gray-900 text-white flex flex-col">
      <div className="p-6 border-b border-gray-800">
        <h1 className="text-orange-500">FastFood Admin</h1>
        <p className="text-gray-400 text-sm mt-1">Panel de Control</p>
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
                  ? 'bg-orange-600 text-white'
                  : 'text-gray-300 hover:bg-gray-800'
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
