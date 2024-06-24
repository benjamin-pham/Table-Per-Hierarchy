namespace TPH.Entities
{
    /// <summary>
    /// người dùng
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// phân loại người dùng
        /// </summary>
        public int UserType { get; set; }
        /// <summary>
        /// tên
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// họ
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// thư điện tử
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;
        /// <summary>
        /// địa chỉ
        /// </summary>
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// tên người dùng
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// mật khẩu băm
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;       
    }
}
