using System.Collections.Generic;

namespace Snapyr.Types
{
    public class Properties : Dictionary<string, string>
    {
        
        // Common Properties
        private const string REVENUE_KEY = "revenue";
        private const string CURRENCY_KEY = "currency";
        private const string VALUE_KEY = "value";
        // Screen Properties
        private const string PATH_KEY = "path";
        private const string REFERRER_KEY = "referrer";
        private const string TITLE_KEY = "title";
        private const string URL_KEY = "url";
        // Ecommerce API
        private const string NAME_KEY = "name"; // used by product too
        private const string CATEGORY_KEY = "category";
        private const string SKU_KEY = "sku";
        private const string PRICE_KEY = "price";
        private const string ID_KEY = "id";
        private const string ORDER_ID_KEY = "orderId";
        private const string TOTAL_KEY = "total";
        private const string SUBTOTAL_KEY = "subtotal";
        private const string SHIPPING_KEY = "shipping";
        private const string TAX_KEY = "tax";
        private const string DISCOUNT_KEY = "discount";
        private const string COUPON_KEY = "coupon";
        private const string PRODUCTS_KEY = "products";
        private const string REPEAT_KEY = "repeat";
        public Properties Put(string key, string val)
        {
            Add(key, val); 
            return this;
        }
    }
}