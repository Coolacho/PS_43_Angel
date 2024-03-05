using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel
{
    public class UserViewModel
    {
        private User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }

        public string Name
        {
            get { return _user.Name; }
            set { _user.Name = value; }
        }

        public string Password
        {
            get
            {
                System.Text.UTF8Encoding encoder = new();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(_user.Password);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string password = new(decoded_char);
                return password;
            }
            set
            {
                try
                {
                    byte[] encData_byte = new byte[value.Length];
                    encData_byte = System.Text.Encoding.UTF8.GetBytes(value);
                    string encodedData = Convert.ToBase64String(encData_byte);
                    _user.Password = encodedData;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in base64Encode" + ex.Message);
                }
            }
        }

        public UserRolesEnum Role
        {
            get { return _user.Role; }
            set { _user.Role = value; }
        }

        public string Email
        {
            get { return _user.Email; }
            set { _user.Email = value; }
        }

        public string Telephone
        {
            get { return _user.Telephone; }
            set { _user.Telephone = value; }
        }

        public string Fac_num
        {
            get { return _user.Fac_num; }
            set { _user.Fac_num = value; }
        }

        public double Grade
        {
            get { return _user.Grade; }
            set { _user.Grade = value; }
        }
    }
}
