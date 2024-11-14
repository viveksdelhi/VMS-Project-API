using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VMS_Project_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialUpdatesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_tbl_Group_GroupId",
                table: "Cameras");

            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_NVR_NVRId",
                table: "Cameras");

            migrationBuilder.AlterColumn<bool>(
                name: "isStreaming",
                table: "Cameras",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "isRecording",
                table: "Cameras",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<int>(
                name: "Port",
                table: "Cameras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PinCode",
                table: "Cameras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NVRId",
                table: "Cameras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Cameras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChannelId",
                table: "Cameras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_tbl_Group_GroupId",
                table: "Cameras",
                column: "GroupId",
                principalTable: "tbl_Group",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_NVR_NVRId",
                table: "Cameras",
                column: "NVRId",
                principalTable: "NVR",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_tbl_Group_GroupId",
                table: "Cameras");

            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_NVR_NVRId",
                table: "Cameras");

            migrationBuilder.AlterColumn<bool>(
                name: "isStreaming",
                table: "Cameras",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isRecording",
                table: "Cameras",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Port",
                table: "Cameras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PinCode",
                table: "Cameras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NVRId",
                table: "Cameras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Cameras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChannelId",
                table: "Cameras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_tbl_Group_GroupId",
                table: "Cameras",
                column: "GroupId",
                principalTable: "tbl_Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_NVR_NVRId",
                table: "Cameras",
                column: "NVRId",
                principalTable: "NVR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
