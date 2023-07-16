namespace Checkout.Domain.Base
{
    public abstract class Entity
    {
        private int _id;

        public virtual int Id
        {
            get => _id;
            set => _id = value;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }
        
        private bool IsTransient()
        {
            return this.Id == default(Int32);
        }
        
        public override int GetHashCode()
        {
            return _id;
        }
    }
}