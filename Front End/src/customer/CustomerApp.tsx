import { useState } from 'react';
import { CustomerHome } from './CustomerHome';
import { CustomerMenu } from './CustomerMenu';
import { CustomerCart } from './CustomerCart';
import { CustomerCheckout } from './CustomerCheckout';
import { CustomerOrderTracking } from './CustomerOrderTracking';
import { CustomerHeader } from './CustomerHeader';

export type CustomerViewType = 'home' | 'menu' | 'cart' | 'checkout' | 'tracking';

export interface CartItem {
  id: string;
  name: string;
  description: string;
  price: number;
  quantity: number;
  category: string;
}

export function CustomerApp() {
  const [currentView, setCurrentView] = useState<CustomerViewType>('home');
  const [cartItems, setCartItems] = useState<CartItem[]>([]);
  const [orderId, setOrderId] = useState<string | null>(null);

  const addToCart = (item: Omit<CartItem, 'quantity'>) => {
    const existingItem = cartItems.find(cartItem => cartItem.id === item.id);
    if (existingItem) {
      setCartItems(cartItems.map(cartItem =>
        cartItem.id === item.id
          ? { ...cartItem, quantity: cartItem.quantity + 1 }
          : cartItem
      ));
    } else {
      setCartItems([...cartItems, { ...item, quantity: 1 }]);
    }
  };

  const updateCartQuantity = (id: string, quantity: number) => {
    if (quantity === 0) {
      setCartItems(cartItems.filter(item => item.id !== id));
    } else {
      setCartItems(cartItems.map(item =>
        item.id === id ? { ...item, quantity } : item
      ));
    }
  };

  const clearCart = () => {
    setCartItems([]);
  };

  const cartItemCount = cartItems.reduce((sum, item) => sum + item.quantity, 0);

  const renderView = () => {
    switch (currentView) {
      case 'home':
        return <CustomerHome onNavigate={setCurrentView} />;
      case 'menu':
        return <CustomerMenu onAddToCart={addToCart} onNavigate={setCurrentView} />;
      case 'cart':
        return (
          <CustomerCart
            items={cartItems}
            onUpdateQuantity={updateCartQuantity}
            onNavigate={setCurrentView}
          />
        );
      case 'checkout':
        return (
          <CustomerCheckout
            items={cartItems}
            onOrderComplete={(id) => {
              setOrderId(id);
              clearCart();
              setCurrentView('tracking');
            }}
            onNavigate={setCurrentView}
          />
        );
      case 'tracking':
        return <CustomerOrderTracking orderId={orderId} onNavigate={setCurrentView} />;
      default:
        return <CustomerHome onNavigate={setCurrentView} />;
    }
  };

  return (
    <div className="min-h-screen bg-gray-50">
      <CustomerHeader
        currentView={currentView}
        onNavigate={setCurrentView}
        cartItemCount={cartItemCount}
      />
      <main>
        {renderView()}
      </main>
    </div>
  );
}
