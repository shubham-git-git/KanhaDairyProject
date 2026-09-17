using KanhaDairy.MODEL.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace KanhaDairy.DAL.Data
{
    public partial class KanhaDairyDbContext : DbContext
    {
        public KanhaDairyDbContext(DbContextOptions<KanhaDairyDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<ItemPrice> ItemPrices { get; set; }
        public virtual DbSet<Logistic> Logistics { get; set; }
        public virtual DbSet<LogisticStatus> LogisticStatus { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentMode> PaymentModes { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Refund> Refunds { get; set; }
        public virtual DbSet<Return> Returns { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<AuditLog> AuditLogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Address1).HasMaxLength(250);
                entity.Property(e => e.Address2).HasMaxLength(250);
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.State).HasMaxLength(50);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_CreatedBy");

                entity.HasOne(d => d.FkUser).WithMany(p => p.AddressFkUsers)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_UserId");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Address_ModifiedBy");
            });

            modelBuilder.Entity<Billing>(entity =>
            {
                entity.ToTable("Billing");
                entity.HasKey(e => e.BillId);                
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
                entity.Property(e => e.FkOrderId).HasColumnName("FK_OrderId");
                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");     
                entity.HasOne(d => d.FkOrder)
                      .WithOne(p => p.Billing)
                      .HasForeignKey<Billing>(d => d.FkOrderId)
                      .HasConstraintName("FK_Billing_Orders");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.FkItemId).HasColumnName("FK_ItemId");
                entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");           
                entity.Property(e => e.FkDiscountId).HasColumnName("Fk_DiscountId");           
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PricePerUnit).HasColumnType("decimal(18, 2)");              

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_CreatedBy");

                entity.HasOne(d => d.FkItem).WithMany(p => p.Carts)
                    .HasForeignKey(d => d.FkItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_ItemId");

                entity.HasOne(d => d.FkUser).WithMany(p => p.CartFkUsers)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_UserId");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Cart_ModifiedBy");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.FkItemId).HasColumnName("FK_ItemId");
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Discounts_CreatedBy");

                entity.HasOne(d => d.FkItem).WithMany(p => p.Discounts)
                    .HasForeignKey(d => d.FkItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Discounts_ItemId");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Discounts_ModifiedBy");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.FkCategoryId).HasColumnName("FK_CategoryId");
                entity.Property(e => e.FkUnitId).HasColumnName("FK_UnitId");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.ItemName).HasMaxLength(50);
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_CreatedBy");

                entity.HasOne(d => d.FkCategory).WithMany(p => p.Items)
                    .HasForeignKey(d => d.FkCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_FK_CategoryId");

                entity.HasOne(d => d.FkUnit).WithMany(p => p.Items)
                    .HasForeignKey(d => d.FkUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_UnitId");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Items_ModifiedBy");
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId).HasName("PK_ItemCategories_1");

                entity.Property(e => e.Category).HasMaxLength(50);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categories_CreatedBy");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Categories_ModifiedBy");
            });

            modelBuilder.Entity<ItemPrice>(entity =>
            {
                entity.HasKey(e => e.PriceId);

                entity.ToTable("ItemPrice");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.FkItemId).HasColumnName("FK_ItemId");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemPrice_CreatedBy");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_ItemPrice_ModifiedBy");
                entity.HasOne(d => d.FkItem)
                    .WithMany()
                    .HasForeignKey(d => d.FkItemId);
            });

            modelBuilder.Entity<Logistic>(entity =>
            {
                entity.ToTable("Logistic");

                entity.Property(e => e.Comments).HasMaxLength(250);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");               
                entity.Property(e => e.FkDeliverById).HasColumnName("FK_DeliverById");
                entity.Property(e => e.FkDeleveryStatusId).HasColumnName("FK_DeleveryStatusId");
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Logistic_CreatedBy");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Logistic_ModifiedBy");
            });

            modelBuilder.Entity<LogisticStatus>(entity =>
            {
                entity.ToTable("LogisticStatus");               
                entity.HasKey(e => e.LogisticStatusId);
                entity.Property(e => e.LogisticStatusId)
                     .ValueGeneratedOnAdd();
                entity.Property(e => e.FkLogisticId)
                      .HasColumnName("FK_LogisticId")
                      .IsRequired();
                entity.Property(e => e.Status)
                      .HasMaxLength(10)
                      .IsRequired();
                entity.Property(e => e.StatusTime)
                      .HasColumnType("datetime2");
                entity.HasOne(e => e.Logistic)
                      .WithMany(l => l.LogisticStatuses) // collection in Logistic
                      .HasForeignKey(e => e.FkLogisticId)
                      .OnDelete(DeleteBehavior.Restrict) // optional
                      .HasConstraintName("FK_LogisticStatus_Logistic");
                              
            });            

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(e => e.OrderId).HasName("PK_Order");

                entity.Property(e => e.Comment).HasMaxLength(250);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.FkLogisticId).HasColumnName("FK_LogisticId");                               
                entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");                
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.FkOrderStatusId).HasColumnName("FK_OrderStatusId");

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_CreatedBy");

                entity.HasOne(d => d.FkOrderStatus).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FkOrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Orders_FK_OrderStatusId");
                
                entity.HasOne(d => d.FkLogistic)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FkLogisticId)
                    .HasConstraintName("FK_Orders_LogisticId");

                entity.HasOne(d => d.FkUser).WithMany(p => p.OrderFkUsers)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_UserId");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Order_ModifiedBy");
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.ToTable("OrderItems");
                entity.HasKey(e => e.OrderItemId).HasName("OrderItemId");
                entity.Property(e => e.FkDiscountId).HasColumnName("FK_DiscountId");
                entity.Property(e => e.FkOrderId).HasColumnName("FK_OrderId");
                entity.Property(e => e.FkItemId).HasColumnName("FK_ItemId");
                // 🔗 Order relation
                entity.HasOne(d => d.FkOrder)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.FkOrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Orders_OrderId");

                // 🔗 Item relation
                entity.HasOne(d => d.FkItem)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.FkItemId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Item_ItemId");

                // 🔗 Discount relation
                entity.HasOne(d => d.FkDiscount)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.FkDiscountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Discount_DiscountId");
                 
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderStatus_CreatedBy");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_OrderStatus_ModifiedBy");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.FkOrderId).HasColumnName("FK_OrderId");
                entity.Property(e => e.FkPaymentModeId).HasColumnName("FK_PaymentModeId");
                entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.TransactionId).HasMaxLength(50);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_CreatedBy");

                entity.HasOne(d => d.FkOrder).WithMany(p => p.Payments)
                    .HasForeignKey(d => d.FkOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_OrderId");

                entity.HasOne(d => d.FkPaymentMode).WithMany(p => p.Payments)
                    .HasForeignKey(d => d.FkPaymentModeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_PaymentModeId");

                entity.HasOne(d => d.FkUser).WithMany(p => p.PaymentFkUsers)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_UserId");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Payment_ModifiedBy");
            });

            modelBuilder.Entity<PaymentMode>(entity =>
            {
                entity.ToTable("PaymentMode");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.PayMode).HasMaxLength(50);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentMode_CreatedBy");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_PaymentMode_ModifiedBy");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("Promotion");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Promotionlog).HasMaxLength(250);
                entity.Property(e => e.Promotiontext).HasMaxLength(250);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Promotion_CreatedBy");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Promotion_ModifiedBy");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.TokenId);

                entity.ToTable("RefreshToken");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");
                entity.Property(e => e.Token)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefreshToken_CreatedBy");

                entity.HasOne(d => d.FkUser).WithMany(p => p.RefreshTokenFkUsers)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefreshToken_UserId");
            });

            modelBuilder.Entity<Refund>(entity =>
            {
                entity.ToTable("Refund");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.FkItemId).HasColumnName("FK_ItemId");
                entity.Property(e => e.FkOrderId).HasColumnName("FK_OrderId");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.RefundAmount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Remark).HasMaxLength(250);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Refund_CreatedBy");

                entity.HasOne(d => d.FkItem).WithMany(p => p.Refunds)
                    .HasForeignKey(d => d.FkItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Refund_ItemId");

                entity.HasOne(d => d.FkOrder).WithMany(p => p.Refunds)
                    .HasForeignKey(d => d.FkOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Refund_OrderId");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Refund_ModifiedBy");
            });

            modelBuilder.Entity<Return>(entity =>
            {
                entity.HasKey(e => e.ReturnId).HasName("PK_Return");

                entity.Property(e => e.Comment).HasMaxLength(250);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.ReturnRegion).HasMaxLength(200);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Return_CreatedBy");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Return_ModifiedBy");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId).HasName("PK_Role");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Roles).HasMaxLength(50);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_CreatedById");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Roles_ModifiedById");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.Abbreviation).HasMaxLength(5);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.UnitName).HasMaxLength(15);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Units_CreatedBy");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Units_ModifiedBy");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.Email).HasMaxLength(30);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.FkRoleId).HasColumnName("FK_RoleId");
                entity.Property(e => e.FkUserTypeId).HasColumnName("FK_UserTypeId");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.Mobile)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.FkRole).WithMany(p => p.Users)
                    .HasForeignKey(d => d.FkRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_RoleId");

                entity.HasOne(d => d.FkUserType).WithMany(p => p.Users)
                    .HasForeignKey(d => d.FkUserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UserTypeId");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_CreatedById");

                entity.HasOne(d => d.ModifiedBy)
                    .WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Users_ModifiedById");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.ToTable("UserLogin");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");
                entity.Property(e => e.PasswordHash).HasMaxLength(100);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserLogin_CreatedBy");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_UserLogin_ModifiedBy");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.UserTypeName).HasMaxLength(50);

                entity.HasOne(d => d.CreatedBy).WithMany()
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserType_CreatedById");

                entity.HasOne(d => d.ModifiedBy).WithMany()
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_UserType_ModifiedById");
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("AuditLogs");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var auditEntries = new List<AuditLog>();
            var userId = 1; //_currentUser.UserId ?? 0;

            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added
                         || e.State == EntityState.Modified
                         || e.State == EntityState.Deleted);

            foreach (var entry in entries)
            {
                // Skip AuditLog itself
                if (entry.Entity is AuditLog) continue;

                // ========================
                // 🔹 CommonEntity handling
                // ========================
                if (entry.Entity is SoftDeleteEntity softEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        softEntity.IsActive = true;                                            
                    }
                    if (entry.State == EntityState.Deleted)
                    {
                        // Soft delete
                        softEntity.IsActive = false;                     
                        entry.State = EntityState.Modified; // convert delete → update
                    }
                }
                // ========================
                // 🔹 AuditEntity handling
                // ========================
                if (entry.Entity is AuditEntity auditEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        auditEntity.CreatedOn = DateTime.Now;
                        auditEntity.CreatedById = userId;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        auditEntity.ModifiedOn = DateTime.Now;
                        auditEntity.ModifiedById = userId;
                    }
                    if (entry.State == EntityState.Deleted)
                    {
                        // Soft delete
                        auditEntity.ModifiedOn = DateTime.Now;
                        auditEntity.ModifiedById = userId;

                    }
                }

                // ========================
                // 🔹 Audit log handling
                // ========================
                var audit = new AuditLog
                {
                    TableName = entry.Entity.GetType().Name,
                    Action = entry.State.ToString(),
                    CreatedAt = DateTime.Now,
                    UserId = userId
                };
                // Old values (for update/delete)
                if (entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
                {
                    audit.OldValues = JsonSerializer.Serialize(entry.OriginalValues.ToObject());
                }
                // New values (for create/update)
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    audit.NewValues = JsonSerializer.Serialize(entry.CurrentValues.ToObject());
                }

                auditEntries.Add(audit);
            }

            // Save main data
            var result = await base.SaveChangesAsync(cancellationToken);

            // Save audit logs
            if (auditEntries.Any())
            {
                AuditLogs.AddRange(auditEntries);
                await base.SaveChangesAsync(cancellationToken);
            }

            return result;
        }        
    }
}