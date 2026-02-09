namespace SoftwarePatterns.Creational.Builder.CustomerProfile
{
    /// <summary>
    /// Representa o perfil completo do cliente.
    /// </summary>
    public class CustomerProfileBuilder
    {
        private SimpleCustomer _simpleCustomer;
        private SocialCustomer _socialCustomer;

        public SimpleCustomer GetSimpleCustomer() => _simpleCustomer;
        public SocialCustomer GetSocialCustomer() => _socialCustomer;

        private CustomerProfileBuilder() { }

        /// <summary>
        /// Builder responsável por montar o CustomerProfileBuilder passo a passo.
        /// </summary>
        public class Builder
        {
            private SimpleCustomer _simpleCustomer;
            private SocialCustomer _socialCustomer;

            public Builder SimpleCustomer(SimpleCustomer simpleCustomer) 
            {
                _simpleCustomer = simpleCustomer;
                return this;
            }

            public Builder SocialCustomer(SocialCustomer socialCustomer)
            {
                _socialCustomer = socialCustomer;
                return this;
            }

            public CustomerProfileBuilder Build()
            {
                return new CustomerProfileBuilder
                {
                    _simpleCustomer = _simpleCustomer,
                    _socialCustomer = _socialCustomer
                };
            }
        }
    }
}