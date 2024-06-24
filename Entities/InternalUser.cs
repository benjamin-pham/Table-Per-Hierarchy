namespace TPH.Entities
{
    public class InternalUser : User
    {
        /// <summary>
        /// quản trị viên cấp cao
        /// </summary>
        public bool IsSuperAdmin { get; set; }
        /// <summary>
        /// quản trị viên
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// chi nhánh
        /// </summary>
        public Guid? BranchId { get; set; }
    }
}
