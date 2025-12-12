import { useState } from 'react';
import { Plus, Pencil, Trash2, Tag, Percent } from 'lucide-react';
import { Card, CardContent, CardHeader, CardTitle } from './ui/card';
import { Button } from './ui/button';
import { Input } from './ui/input';
import { Label } from './ui/label';
import { Badge } from './ui/badge';
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogFooter } from './ui/dialog';
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select';
import { Switch } from './ui/switch';

interface Promotion {
  id: string;
  name: string;
  type: 'percentage' | 'fixed' | 'combo';
  discount: number;
  active: boolean;
  conditions?: string;
}

export function PromotionsManagement() {
  const [promotions, setPromotions] = useState<Promotion[]>([
    { id: '1', name: 'Descuento 10% en Hamburguesas', type: 'percentage', discount: 10, active: true, conditions: 'En hamburguesas' },
    { id: '2', name: 'Descuento $5 en compras mayores a $30', type: 'fixed', discount: 5, active: true, conditions: 'Compra mínima $30' },
    { id: '3', name: 'Combo 2x1 en Bebidas', type: 'combo', discount: 50, active: true, conditions: '2x1' },
    { id: '4', name: '15% Descuento Martes', type: 'percentage', discount: 15, active: false, conditions: 'Solo martes' },
  ]);

  const [showDialog, setShowDialog] = useState(false);
  const [editingPromotion, setEditingPromotion] = useState<Promotion | null>(null);
  const [formData, setFormData] = useState({
    name: '',
    type: 'percentage' as 'percentage' | 'fixed' | 'combo',
    discount: '',
    conditions: '',
  });

  const openDialog = (promotion?: Promotion) => {
    if (promotion) {
      setEditingPromotion(promotion);
      setFormData({
        name: promotion.name,
        type: promotion.type,
        discount: promotion.discount.toString(),
        conditions: promotion.conditions || '',
      });
    } else {
      setEditingPromotion(null);
      setFormData({ name: '', type: 'percentage', discount: '', conditions: '' });
    }
    setShowDialog(true);
  };

  const handleSave = () => {
    if (!formData.name || !formData.discount) {
      alert('Por favor completa todos los campos');
      return;
    }

    if (editingPromotion) {
      setPromotions(promotions.map(p =>
        p.id === editingPromotion.id
          ? {
              ...p,
              name: formData.name,
              type: formData.type,
              discount: parseFloat(formData.discount),
              conditions: formData.conditions,
            }
          : p
      ));
    } else {
      const newPromotion: Promotion = {
        id: Date.now().toString(),
        name: formData.name,
        type: formData.type,
        discount: parseFloat(formData.discount),
        active: true,
        conditions: formData.conditions,
      };
      setPromotions([...promotions, newPromotion]);
    }
    setShowDialog(false);
  };

  const toggleActive = (id: string) => {
    setPromotions(promotions.map(p =>
      p.id === id ? { ...p, active: !p.active } : p
    ));
  };

  const deletePromotion = (id: string) => {
    if (confirm('¿Estás seguro de eliminar esta promoción?')) {
      setPromotions(promotions.filter(p => p.id !== id));
    }
  };

  const getTypeIcon = (type: string) => {
    switch (type) {
      case 'percentage':
        return <Percent className="w-4 h-4" />;
      case 'fixed':
        return <span className="text-sm">$</span>;
      case 'combo':
        return <Tag className="w-4 h-4" />;
      default:
        return null;
    }
  };

  const getTypeLabel = (type: string) => {
    switch (type) {
      case 'percentage':
        return 'Porcentaje';
      case 'fixed':
        return 'Fijo';
      case 'combo':
        return 'Combo';
      default:
        return type;
    }
  };

  return (
    <div className="p-8">
      <div className="mb-6">
        <h1 className="text-gray-900 mb-2">Promociones y Combos</h1>
        <p className="text-gray-600">Gestiona las promociones activas</p>
      </div>

      <div className="mb-6 flex justify-between items-center">
        <div className="flex gap-4">
          <Card className="px-4 py-2">
            <div className="flex items-center gap-2">
              <div className="w-2 h-2 bg-green-500 rounded-full"></div>
              <span className="text-gray-600 text-sm">
                {promotions.filter(p => p.active).length} Activas
              </span>
            </div>
          </Card>
          <Card className="px-4 py-2">
            <div className="flex items-center gap-2">
              <div className="w-2 h-2 bg-gray-400 rounded-full"></div>
              <span className="text-gray-600 text-sm">
                {promotions.filter(p => !p.active).length} Inactivas
              </span>
            </div>
          </Card>
        </div>
        <Button onClick={() => openDialog()} className="bg-orange-600 hover:bg-orange-700">
          <Plus className="w-4 h-4 mr-2" />
          Nueva Promoción
        </Button>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {promotions.map((promotion) => (
          <Card key={promotion.id} className={!promotion.active ? 'opacity-60' : ''}>
            <CardHeader>
              <div className="flex items-start justify-between">
                <div className="flex items-center gap-2">
                  <div className="w-10 h-10 bg-orange-100 rounded-full flex items-center justify-center text-orange-600">
                    {getTypeIcon(promotion.type)}
                  </div>
                  <div>
                    <Badge variant="secondary" className="mb-1">
                      {getTypeLabel(promotion.type)}
                    </Badge>
                    <CardTitle className="text-base">{promotion.name}</CardTitle>
                  </div>
                </div>
              </div>
            </CardHeader>
            <CardContent>
              <div className="space-y-3">
                <div className="flex items-center justify-between">
                  <span className="text-gray-600">Descuento:</span>
                  <span className="text-2xl text-orange-600">
                    {promotion.type === 'percentage' ? `${promotion.discount}%` : `$${promotion.discount}`}
                  </span>
                </div>
                {promotion.conditions && (
                  <p className="text-sm text-gray-600">{promotion.conditions}</p>
                )}
                <div className="flex items-center justify-between pt-3 border-t">
                  <div className="flex items-center gap-2">
                    <Switch
                      checked={promotion.active}
                      onCheckedChange={() => toggleActive(promotion.id)}
                    />
                    <span className="text-sm text-gray-600">
                      {promotion.active ? 'Activa' : 'Inactiva'}
                    </span>
                  </div>
                  <div className="flex gap-1">
                    <Button
                      variant="ghost"
                      size="sm"
                      onClick={() => openDialog(promotion)}
                    >
                      <Pencil className="w-4 h-4" />
                    </Button>
                    <Button
                      variant="ghost"
                      size="sm"
                      onClick={() => deletePromotion(promotion.id)}
                    >
                      <Trash2 className="w-4 h-4 text-red-500" />
                    </Button>
                  </div>
                </div>
              </div>
            </CardContent>
          </Card>
        ))}
      </div>

      <Dialog open={showDialog} onOpenChange={setShowDialog}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>
              {editingPromotion ? 'Editar Promoción' : 'Nueva Promoción'}
            </DialogTitle>
          </DialogHeader>
          <div className="space-y-4 py-4">
            <div className="space-y-2">
              <Label htmlFor="promo-name">Nombre de la Promoción</Label>
              <Input
                id="promo-name"
                value={formData.name}
                onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                placeholder="Ej: Descuento 10% en Hamburguesas"
              />
            </div>
            <div className="space-y-2">
              <Label htmlFor="promo-type">Tipo de Promoción</Label>
              <Select
                value={formData.type}
                onValueChange={(value: 'percentage' | 'fixed' | 'combo') =>
                  setFormData({ ...formData, type: value })
                }
              >
                <SelectTrigger>
                  <SelectValue />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="percentage">Porcentaje</SelectItem>
                  <SelectItem value="fixed">Descuento Fijo</SelectItem>
                  <SelectItem value="combo">Combo/2x1</SelectItem>
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-2">
              <Label htmlFor="promo-discount">
                {formData.type === 'percentage' ? 'Porcentaje de Descuento' : 'Monto de Descuento'}
              </Label>
              <Input
                id="promo-discount"
                type="number"
                step="0.01"
                value={formData.discount}
                onChange={(e) => setFormData({ ...formData, discount: e.target.value })}
                placeholder={formData.type === 'percentage' ? '10' : '5.00'}
              />
            </div>
            <div className="space-y-2">
              <Label htmlFor="promo-conditions">Condiciones (Opcional)</Label>
              <Input
                id="promo-conditions"
                value={formData.conditions}
                onChange={(e) => setFormData({ ...formData, conditions: e.target.value })}
                placeholder="Ej: Válido solo los martes"
              />
            </div>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setShowDialog(false)}>
              Cancelar
            </Button>
            <Button onClick={handleSave} className="bg-orange-600 hover:bg-orange-700">
              {editingPromotion ? 'Guardar Cambios' : 'Crear Promoción'}
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}
