using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreRelationships.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hierarchicals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hierarchicals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hierarchicals_Hierarchicals_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Hierarchicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManyToManyLefts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyToManyLefts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManyToManyRelationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyToManyRelationships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManyToManyRights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyToManyRights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotRelateds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotRelateds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OneToManyOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneToManyOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OneToManys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneToManys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OneToOneOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Owned_Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneToOneOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManyToManyWithModeledLefts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RelationshipId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyToManyWithModeledLefts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManyToManyWithModeledLefts_ManyToManyRelationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "ManyToManyRelationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManyToManyWithModeledRights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RelationshipId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyToManyWithModeledRights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManyToManyWithModeledRights_ManyToManyRelationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "ManyToManyRelationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManyToManyLeftManyToManyRight",
                columns: table => new
                {
                    LeftsId = table.Column<int>(type: "INTEGER", nullable: false),
                    RightsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyToManyLeftManyToManyRight", x => new { x.LeftsId, x.RightsId });
                    table.ForeignKey(
                        name: "FK_ManyToManyLeftManyToManyRight_ManyToManyLefts_LeftsId",
                        column: x => x.LeftsId,
                        principalTable: "ManyToManyLefts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManyToManyLeftManyToManyRight_ManyToManyRights_RightsId",
                        column: x => x.RightsId,
                        principalTable: "ManyToManyRights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OneToManyOwnedItem",
                columns: table => new
                {
                    OneToManyOwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneToManyOwnedItem", x => new { x.OneToManyOwnerId, x.Id });
                    table.ForeignKey(
                        name: "FK_OneToManyOwnedItem_OneToManyOwners_OneToManyOwnerId",
                        column: x => x.OneToManyOwnerId,
                        principalTable: "OneToManyOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OneToManyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OneToManyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneToManyItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneToManyItems_OneToManys_OneToManyId",
                        column: x => x.OneToManyId,
                        principalTable: "OneToManys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OneToOneRights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    OneToOneLeftId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneToOneRights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OneToOneLefts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OneToOneRightId = table.Column<int>(type: "INTEGER", nullable: false),
                    RightId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneToOneLefts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneToOneLefts_OneToOneRights_RightId",
                        column: x => x.RightId,
                        principalTable: "OneToOneRights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchicals_ParentId",
                table: "Hierarchicals",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ManyToManyLeftManyToManyRight_RightsId",
                table: "ManyToManyLeftManyToManyRight",
                column: "RightsId");

            migrationBuilder.CreateIndex(
                name: "IX_ManyToManyWithModeledLefts_RelationshipId",
                table: "ManyToManyWithModeledLefts",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_ManyToManyWithModeledRights_RelationshipId",
                table: "ManyToManyWithModeledRights",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_OneToManyItems_OneToManyId",
                table: "OneToManyItems",
                column: "OneToManyId");

            migrationBuilder.CreateIndex(
                name: "IX_OneToOneLefts_RightId",
                table: "OneToOneLefts",
                column: "RightId");

            migrationBuilder.AddForeignKey(
                name: "FK_OneToOneRights_OneToOneLefts_Id",
                table: "OneToOneRights",
                column: "Id",
                principalTable: "OneToOneLefts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OneToOneLefts_OneToOneRights_RightId",
                table: "OneToOneLefts");

            migrationBuilder.DropTable(
                name: "Hierarchicals");

            migrationBuilder.DropTable(
                name: "ManyToManyLeftManyToManyRight");

            migrationBuilder.DropTable(
                name: "ManyToManyWithModeledLefts");

            migrationBuilder.DropTable(
                name: "ManyToManyWithModeledRights");

            migrationBuilder.DropTable(
                name: "NotRelateds");

            migrationBuilder.DropTable(
                name: "OneToManyItems");

            migrationBuilder.DropTable(
                name: "OneToManyOwnedItem");

            migrationBuilder.DropTable(
                name: "OneToOneOwners");

            migrationBuilder.DropTable(
                name: "ManyToManyLefts");

            migrationBuilder.DropTable(
                name: "ManyToManyRights");

            migrationBuilder.DropTable(
                name: "ManyToManyRelationships");

            migrationBuilder.DropTable(
                name: "OneToManys");

            migrationBuilder.DropTable(
                name: "OneToManyOwners");

            migrationBuilder.DropTable(
                name: "OneToOneRights");

            migrationBuilder.DropTable(
                name: "OneToOneLefts");
        }
    }
}
