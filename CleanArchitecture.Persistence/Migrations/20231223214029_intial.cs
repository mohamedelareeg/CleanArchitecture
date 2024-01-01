using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barcodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeBarcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repositories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Storage = table.Column<int>(type: "int", nullable: false),
                    SaveLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Privacy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repositories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormBarcodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormsId = table.Column<int>(type: "int", nullable: false),
                    BarcodesId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormBarcodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormBarcodes_Barcodes_BarcodesId",
                        column: x => x.BarcodesId,
                        principalTable: "Barcodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormBarcodes_Forms_FormsId",
                        column: x => x.FormsId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepositoryId = table.Column<int>(type: "int", nullable: true),
                    ParentFolderId = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsProtected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryFolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryFolders_Repositories_RepositoryId",
                        column: x => x.RepositoryId,
                        principalTable: "Repositories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepositoryFolders_RepositoryFolders_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalTable: "RepositoryFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedFormId = table.Column<int>(type: "int", nullable: false),
                    SelectedRepositoriesId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryForms_Forms_SelectedFormId",
                        column: x => x.SelectedFormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepositoryForms_Repositories_SelectedRepositoriesId",
                        column: x => x.SelectedRepositoriesId,
                        principalTable: "Repositories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepositoryId = table.Column<int>(type: "int", nullable: true),
                    InputType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryMetadata_Repositories_RepositoryId",
                        column: x => x.RepositoryId,
                        principalTable: "Repositories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FolderId = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsProtected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryDocuments_Forms_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepositoryDocuments_RepositoryFolders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "RepositoryFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryFormImports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedFormId = table.Column<int>(type: "int", nullable: false),
                    SelectedRepositoriesId = table.Column<int>(type: "int", nullable: false),
                    PublishFolderId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryFormImports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryFormImports_Forms_SelectedFormId",
                        column: x => x.SelectedFormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepositoryFormImports_Repositories_SelectedRepositoriesId",
                        column: x => x.SelectedRepositoriesId,
                        principalTable: "Repositories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepositoryFormImports_RepositoryFolders_PublishFolderId",
                        column: x => x.PublishFolderId,
                        principalTable: "RepositoryFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryMetadataOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepositoryMetadataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryMetadataOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryMetadataOption_RepositoryMetadata_RepositoryMetadataId",
                        column: x => x.RepositoryMetadataId,
                        principalTable: "RepositoryMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsProtected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryFiles_RepositoryDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "RepositoryDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryFileMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    RepositoryMetadataId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryFileMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryFileMetadata_RepositoryFiles_FileId",
                        column: x => x.FileId,
                        principalTable: "RepositoryFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepositoryFileMetadata_RepositoryMetadata_RepositoryMetadataId",
                        column: x => x.RepositoryMetadataId,
                        principalTable: "RepositoryMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryFileRedacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    PageNumber = table.Column<int>(type: "int", nullable: false),
                    Left = table.Column<double>(type: "float", nullable: false),
                    Top = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Fill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextWidth = table.Column<double>(type: "float", nullable: true),
                    TextHeight = table.Column<double>(type: "float", nullable: true),
                    RectBorderThickness = table.Column<int>(type: "int", nullable: true),
                    RectBorderColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextFontSize = table.Column<int>(type: "int", nullable: true),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResizeWidth = table.Column<double>(type: "float", nullable: true),
                    ResizeHeight = table.Column<double>(type: "float", nullable: true),
                    Identifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryFileRedacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryFileRedacts_RepositoryFiles_FileId",
                        column: x => x.FileId,
                        principalTable: "RepositoryFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryPermissons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FolderId = table.Column<int>(type: "int", nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    FileId = table.Column<int>(type: "int", nullable: true),
                    FormId = table.Column<int>(type: "int", nullable: true),
                    Permission = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryPermissons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryPermissons_Employees_UserId",
                        column: x => x.UserId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepositoryPermissons_RepositoryDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "RepositoryDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepositoryPermissons_RepositoryFiles_FileId",
                        column: x => x.FileId,
                        principalTable: "RepositoryFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepositoryPermissons_RepositoryFolders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "RepositoryFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepositoryPermissons_RepositoryForms_FormId",
                        column: x => x.FormId,
                        principalTable: "RepositoryForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldImportDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    FieldType = table.Column<int>(type: "int", nullable: false),
                    RepositoryFormImportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldImportDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldImportDatas_RepositoryFormImports_RepositoryFormImportId",
                        column: x => x.RepositoryFormImportId,
                        principalTable: "RepositoryFormImports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldOptionLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldsId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CascadingFieldOptionsId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOptionLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldOptionLists_FieldOptionLists_CascadingFieldOptionsId",
                        column: x => x.CascadingFieldOptionsId,
                        principalTable: "FieldOptionLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldsId = table.Column<int>(type: "int", nullable: true),
                    MaxLength = table.Column<int>(type: "int", nullable: true),
                    regularExpression = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Digits = table.Column<int>(type: "int", nullable: true),
                    DecmialPlaces = table.Column<int>(type: "int", nullable: true),
                    DateFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FieldTypeId = table.Column<int>(type: "int", nullable: false),
                    FieldOptionId = table.Column<int>(type: "int", nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    CascadingFieldId = table.Column<int>(type: "int", nullable: true),
                    Unique = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_FieldOptions_FieldOptionId",
                        column: x => x.FieldOptionId,
                        principalTable: "FieldOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fields_FieldTypes_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "FieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fields_Fields_CascadingFieldId",
                        column: x => x.CascadingFieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldOptionValidations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    MaxLength = table.Column<int>(type: "int", nullable: true),
                    IsNumbric = table.Column<bool>(type: "bit", nullable: false),
                    CascadingFieldOptionsId = table.Column<int>(type: "int", nullable: true),
                    FieldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOptionValidations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldOptionValidations_FieldOptionLists_CascadingFieldOptionsId",
                        column: x => x.CascadingFieldOptionsId,
                        principalTable: "FieldOptionLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FieldOptionValidations_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormsId = table.Column<int>(type: "int", nullable: false),
                    FieldsId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormFields_Fields_FieldsId",
                        column: x => x.FieldsId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormFields_Forms_FormsId",
                        column: x => x.FormsId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryDocumentFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryDocumentFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryDocumentFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepositoryDocumentFields_RepositoryDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "RepositoryDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldImportDatas_FieldId",
                table: "FieldImportDatas",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldImportDatas_RepositoryFormImportId",
                table: "FieldImportDatas",
                column: "RepositoryFormImportId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldOptionLists_CascadingFieldOptionsId",
                table: "FieldOptionLists",
                column: "CascadingFieldOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldOptionLists_FieldsId",
                table: "FieldOptionLists",
                column: "FieldsId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldOptions_FieldsId",
                table: "FieldOptions",
                column: "FieldsId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldOptionValidations_CascadingFieldOptionsId",
                table: "FieldOptionValidations",
                column: "CascadingFieldOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldOptionValidations_FieldId",
                table: "FieldOptionValidations",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_CascadingFieldId",
                table: "Fields",
                column: "CascadingFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FieldOptionId",
                table: "Fields",
                column: "FieldOptionId",
                unique: true,
                filter: "[FieldOptionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FieldTypeId",
                table: "Fields",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBarcodes_BarcodesId",
                table: "FormBarcodes",
                column: "BarcodesId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBarcodes_FormsId",
                table: "FormBarcodes",
                column: "FormsId");

            migrationBuilder.CreateIndex(
                name: "IX_FormFields_FieldsId",
                table: "FormFields",
                column: "FieldsId");

            migrationBuilder.CreateIndex(
                name: "IX_FormFields_FormsId",
                table: "FormFields",
                column: "FormsId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryDocumentFields_DocumentId",
                table: "RepositoryDocumentFields",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryDocumentFields_FieldId",
                table: "RepositoryDocumentFields",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryDocuments_DocumentTypeId",
                table: "RepositoryDocuments",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryDocuments_FolderId",
                table: "RepositoryDocuments",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryFileMetadata_FileId",
                table: "RepositoryFileMetadata",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryFileMetadata_RepositoryMetadataId",
                table: "RepositoryFileMetadata",
                column: "RepositoryMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryFileRedacts_FileId",
                table: "RepositoryFileRedacts",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryFiles_DocumentId",
                table: "RepositoryFiles",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryFolders_ParentFolderId",
                table: "RepositoryFolders",
                column: "ParentFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryFolders_RepositoryId",
                table: "RepositoryFolders",
                column: "RepositoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryFormImports_PublishFolderId",
                table: "RepositoryFormImports",
                column: "PublishFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryFormImports_SelectedFormId",
                table: "RepositoryFormImports",
                column: "SelectedFormId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryFormImports_SelectedRepositoriesId",
                table: "RepositoryFormImports",
                column: "SelectedRepositoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryForms_SelectedFormId",
                table: "RepositoryForms",
                column: "SelectedFormId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryForms_SelectedRepositoriesId",
                table: "RepositoryForms",
                column: "SelectedRepositoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryMetadata_RepositoryId",
                table: "RepositoryMetadata",
                column: "RepositoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryMetadataOption_RepositoryMetadataId",
                table: "RepositoryMetadataOption",
                column: "RepositoryMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryPermissons_DocumentId",
                table: "RepositoryPermissons",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryPermissons_FileId",
                table: "RepositoryPermissons",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryPermissons_FolderId",
                table: "RepositoryPermissons",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryPermissons_FormId",
                table: "RepositoryPermissons",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryPermissons_UserId",
                table: "RepositoryPermissons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldImportDatas_Fields_FieldId",
                table: "FieldImportDatas",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldOptionLists_Fields_FieldsId",
                table: "FieldOptionLists",
                column: "FieldsId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldOptions_Fields_FieldsId",
                table: "FieldOptions",
                column: "FieldsId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldOptions_Fields_FieldsId",
                table: "FieldOptions");

            migrationBuilder.DropTable(
                name: "FieldImportDatas");

            migrationBuilder.DropTable(
                name: "FieldOptionValidations");

            migrationBuilder.DropTable(
                name: "FormBarcodes");

            migrationBuilder.DropTable(
                name: "FormFields");

            migrationBuilder.DropTable(
                name: "RepositoryDocumentFields");

            migrationBuilder.DropTable(
                name: "RepositoryFileMetadata");

            migrationBuilder.DropTable(
                name: "RepositoryFileRedacts");

            migrationBuilder.DropTable(
                name: "RepositoryMetadataOption");

            migrationBuilder.DropTable(
                name: "RepositoryPermissons");

            migrationBuilder.DropTable(
                name: "RepositoryFormImports");

            migrationBuilder.DropTable(
                name: "FieldOptionLists");

            migrationBuilder.DropTable(
                name: "Barcodes");

            migrationBuilder.DropTable(
                name: "RepositoryMetadata");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "RepositoryFiles");

            migrationBuilder.DropTable(
                name: "RepositoryForms");

            migrationBuilder.DropTable(
                name: "RepositoryDocuments");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "RepositoryFolders");

            migrationBuilder.DropTable(
                name: "Repositories");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "FieldOptions");

            migrationBuilder.DropTable(
                name: "FieldTypes");
        }
    }
}
