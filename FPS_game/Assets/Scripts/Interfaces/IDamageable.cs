namespace FPS
{
    public interface IDamageable
    {
        void ApplyDamage(float damage);
        float MaxHealth { get; }
        float CurrentHealth { get; }
    }
}