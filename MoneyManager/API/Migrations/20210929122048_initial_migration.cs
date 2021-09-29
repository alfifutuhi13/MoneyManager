using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Expense",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Expense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Income",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Income", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Parameter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Parameter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 12, nullable: false),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_User_TB_M_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TB_M_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Account_TB_M_User_Id",
                        column: x => x.Id,
                        principalTable: "TB_M_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Transaction_TB_M_User_Id",
                        column: x => x.Id,
                        principalTable: "TB_M_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_TransactionExpense",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(nullable: true),
                    ExpenseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_TransactionExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_TransactionExpense_TB_M_Expense_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "TB_M_Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_T_TransactionExpense_TB_M_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "TB_M_Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_TransactionIncome",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(nullable: true),
                    IncomeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_TransactionIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_TransactionIncome_TB_M_Income_IncomeId",
                        column: x => x.IncomeId,
                        principalTable: "TB_M_Income",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_T_TransactionIncome_TB_M_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "TB_M_Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_User_Email",
                table: "TB_M_User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_User_RoleId",
                table: "TB_M_User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_TransactionExpense_ExpenseId",
                table: "TB_T_TransactionExpense",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_TransactionExpense_TransactionId",
                table: "TB_T_TransactionExpense",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_TransactionIncome_IncomeId",
                table: "TB_T_TransactionIncome",
                column: "IncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_TransactionIncome_TransactionId",
                table: "TB_T_TransactionIncome",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Account");

            migrationBuilder.DropTable(
                name: "TB_M_Parameter");

            migrationBuilder.DropTable(
                name: "TB_T_TransactionExpense");

            migrationBuilder.DropTable(
                name: "TB_T_TransactionIncome");

            migrationBuilder.DropTable(
                name: "TB_M_Expense");

            migrationBuilder.DropTable(
                name: "TB_M_Income");

            migrationBuilder.DropTable(
                name: "TB_M_Transaction");

            migrationBuilder.DropTable(
                name: "TB_M_User");

            migrationBuilder.DropTable(
                name: "TB_M_Role");
        }
    }
}
