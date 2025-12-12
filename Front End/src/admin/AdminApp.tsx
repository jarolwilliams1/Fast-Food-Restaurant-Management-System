import { useState } from 'react';
import { AdminDashboard } from './AdminDashboard';
import { OnlineOrdersManagement } from './OnlineOrdersManagement';
import { MenuManagement } from './MenuManagement';
import { LocalPOS } from './LocalPOS';
import { PromotionsManagement } from './PromotionsManagement';
import { Reports } from './Reports';
import { AdminSidebar } from './AdminSidebar';

export type AdminViewType = 'dashboard' | 'online-orders' | 'menu' | 'local-pos' | 'promotions' | 'reports';

export function AdminApp() {
  const [currentView, setCurrentView] = useState<AdminViewType>('dashboard');

  const renderView = () => {
    switch (currentView) {
      case 'dashboard':
        return <AdminDashboard onNavigate={setCurrentView} />;
      case 'online-orders':
        return <OnlineOrdersManagement />;
      case 'menu':
        return <MenuManagement />;
      case 'local-pos':
        return <LocalPOS />;
      case 'promotions':
        return <PromotionsManagement />;
      case 'reports':
        return <Reports />;
      default:
        return <AdminDashboard onNavigate={setCurrentView} />;
    }
  };

  return (
    <div className="flex h-screen bg-gray-50">
      <AdminSidebar currentView={currentView} onNavigate={setCurrentView} />
      <main className="flex-1 overflow-auto">
        {renderView()}
      </main>
    </div>
  );
}
