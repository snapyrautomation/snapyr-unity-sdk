using System.Collections.Generic;

namespace Snapyr.Types
{
    public class Traits : Dictionary<string, object>
    {
        private const string AVATAR_KEY = "avatar";
        private const string CREATED_AT_KEY = "createdAt";
        private const string DESCRIPTION_KEY = "description";
        private const string EMAIL_KEY = "email";
        private const string FAX_KEY = "fax";
        private const string ANONYMOUS_ID_KEY = "anonymousId";
        private const string USER_ID_KEY = "userId";
        private const string NAME_KEY = "name";
        private const string PHONE_KEY = "phone";

        private const string WEBSITE_KEY = "website";

        // For Identify Calls
        private const string AGE_KEY = "age";
        private const string BIRTHDAY_KEY = "birthday";
        private const string FIRST_NAME_KEY = "firstName";
        private const string GENDER_KEY = "gender";
        private const string LAST_NAME_KEY = "lastName";
        private const string TITLE_KEY = "title";

        private const string USERNAME_KEY = "username";

        // For Group calls
        private const string EMPLOYEES_KEY = "employees";

        private const string INDUSTRY_KEY = "industry";

        // Address
        private const string ADDRESS_KEY = "address";

        public Traits Put(string key, string val)
        {
            base.Add(key, val);
            return this;
        }

        public Traits Put(string key, int val)
        {
            base.Add(key, val);
            return this;
        }

        public Traits Put(string key, double val)
        {
            base.Add(key, val);
            return this;
        }

        public Traits Put(string key, bool val)
        {
            base.Add(key, val);
            return this;
        }

        public new void Add(string key, object val)
        {
            throw new System.NotSupportedException("Calling Add() directly is not supported. Use Put() instead.");
        }

        public Traits PutUserId(string val) => Put(USER_ID_KEY, val);
        public Traits PutAnonymousId(string val) => Put(ANONYMOUS_ID_KEY, val);
        public Traits PutEmail(string val) => Put(EMAIL_KEY, val);
        public Traits PutFirstName(string val) => Put(FIRST_NAME_KEY, val);
        public Traits PutLastName(string val) => Put(LAST_NAME_KEY, val);
        public Traits PutGender(string val) => Put(GENDER_KEY, val);
        public Traits PutTitle(string val) => Put(TITLE_KEY, val);
        public Traits PutIndustry(string val) => Put(INDUSTRY_KEY, val);
        public Traits PutFax(string val) => Put(FAX_KEY, val);
        public Traits PutDescription(string val) => Put(DESCRIPTION_KEY, val);
        public Traits PutCreatedAt(string val) => Put(CREATED_AT_KEY, val);
        public Traits PutAvatar(string val) => Put(AVATAR_KEY, val);
        public Traits PutAge(int val) => Put(AGE_KEY, val.ToString());
        public Traits PutEmployees(int val) => Put(EMPLOYEES_KEY, val.ToString());
        public Traits PutName(string val) => Put(NAME_KEY, val);
        public Traits PutPhone(string val) => Put(PHONE_KEY, val);
        public Traits PutUsername(string val) => Put(USERNAME_KEY, val);
        public Traits PutWebsite(string val) => Put(WEBSITE_KEY, val);
    }
}