using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Celebrities",
                columns: table => new
                {
                    CelebrityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CountViews = table.Column<int>(nullable: false),
                    ImageSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celebrities", x => x.CelebrityId);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentType = table.Column<int>(nullable: false),
                    ContentId = table.Column<int>(nullable: false),
                    AddedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    JobTitleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.JobTitleId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    ReleaseYear = table.Column<int>(nullable: false),
                    ImageSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Serials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    PosterImageSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    UserPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<string>(maxLength: 2000, nullable: false),
                    CountViews = table.Column<int>(nullable: false),
                    PreviewImage = table.Column<string>(nullable: false),
                    PublishTime = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CelebrityJobTitles",
                columns: table => new
                {
                    CelebrityId = table.Column<int>(nullable: false),
                    JobTitleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelebrityJobTitles", x => new { x.CelebrityId, x.JobTitleId });
                    table.ForeignKey(
                        name: "FK_CelebrityJobTitles_Celebrities_CelebrityId",
                        column: x => x.CelebrityId,
                        principalTable: "Celebrities",
                        principalColumn: "CelebrityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CelebrityJobTitles_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "JobTitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorsLists",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorsLists", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_ActorsLists_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorsLists_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SerialCelebrities",
                columns: table => new
                {
                    SerialId = table.Column<int>(nullable: false),
                    CelebrityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialCelebrities", x => new { x.SerialId, x.CelebrityId });
                    table.ForeignKey(
                        name: "FK_SerialCelebrities_Celebrities_CelebrityId",
                        column: x => x.CelebrityId,
                        principalTable: "Celebrities",
                        principalColumn: "CelebrityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SerialCelebrities_Serials_SerialId",
                        column: x => x.SerialId,
                        principalTable: "Serials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SerialGenreTitles",
                columns: table => new
                {
                    SerialId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialGenreTitles", x => new { x.SerialId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_SerialGenreTitles_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SerialGenreTitles_Serials_SerialId",
                        column: x => x.SerialId,
                        principalTable: "Serials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    FilmId = table.Column<int>(nullable: false),
                    ContentType = table.Column<int>(nullable: false),
                    ReviewTitle = table.Column<string>(maxLength: 150, nullable: false),
                    ReviewContent = table.Column<string>(maxLength: 2000, nullable: false),
                    PublishTime = table.Column<DateTime>(nullable: false),
                    DirectingRating = table.Column<float>(nullable: false),
                    PlotRating = table.Column<float>(nullable: false),
                    SpectacleRating = table.Column<float>(nullable: false),
                    ActorsRating = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsCategories",
                columns: table => new
                {
                    NewsId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategories", x => new { x.CategoryId, x.NewsId });
                    table.ForeignKey(
                        name: "FK_NewsCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsCategories_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 19, "Джим Керри" },
                    { 2, "Филисити Джонс" },
                    { 3, "Эдди Редмейн" },
                    { 4, "Химет Патель" },
                    { 5, "Режиссер" },
                    { 6, "Джордж Маккей" },
                    { 7, "Дин-Чарльз Чакман" },
                    { 8, "Ричард Мэдден" },
                    { 9, "Джордж Нолфи" },
                    { 10, "Энтони Маки" },
                    { 11, "Сэмюел Лерой Джексон" },
                    { 12, "Ниа Лонг" },
                    { 13, "Джейк Кэздан" },
                    { 14, "Дуэйн Джонсон" },
                    { 15, "Карен Гиллан" },
                    { 16, "Джейк Блэк" },
                    { 17, "Кевин Харт" },
                    { 18, "Джефф Фаулер" },
                    { 29, "Тимоти Шаламе" },
                    { 20, "Джеймс Марсден" },
                    { 21, "Тика Самптер" },
                    { 22, "Бен Шварц" },
                    { 23, "Мэти Янь" },
                    { 24, "Марго Робби" },
                    { 25, "Джерни Смоллет-Белл" },
                    { 26, "Мэри Элизабет Уинстэд" },
                    { 1, "Том Харпер" },
                    { 30, "Флоренс Пью" },
                    { 31, "Эмма Уотсон" },
                    { 32, "Сирзат Яхуп" },
                    { 43, "Элайза Сканлен" },
                    { 42, "Наташа Ротуэлл" },
                    { 27, "Грета Гервич" },
                    { 41, "Николас Холт" },
                    { 40, "Ник Джонас" },
                    { 39, "Бенедикт Камбербэтч" },
                    { 28, "Сирта Ронан" },
                    { 37, "Фиби Фокс" },
                    { 36, "Аружан Джазильбекова" },
                    { 38, "Левин Ллойд" },
                    { 33, "Ху Цзюнь" },
                    { 34, "Юань Цуань" },
                    { 35, "Берик Айтжанов" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Мария", "Колосова" },
                    { 3, "Мия", "Набу" },
                    { 2, "Пабло", "Мироненко" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Variety" },
                    { 2, "FilmNews" }
                });

            migrationBuilder.InsertData(
                table: "Celebrities",
                columns: new[] { "CelebrityId", "CountViews", "FirstName", "ImageSource", "LastName" },
                values: new object[,]
                {
                    { -1, 134000, "Хью", "StaticFiles/images/1.jpg", "Джекман" },
                    { -3, 126000, "Роберт", "StaticFiles/images/3.jpg", "Дауни (младший)" },
                    { -4, 121000, "Уилл", "StaticFiles/images/4.jpg", "Смит" },
                    { -5, 120500, "Брэд", "StaticFiles/images/5.jpg", "Питт" },
                    { -6, 120000, "Леонардо", "StaticFiles/images/6.jpg", "Ди Каприо" },
                    { -7, 91000, "Натали", "StaticFiles/images/7.jpg", "Портман" },
                    { -8, 20000, "Роджер", "StaticFiles/images/8.jpg", "Дикинс" },
                    { -9, 50000, "Ханс", "StaticFiles/images/9.png", "Циммер" },
                    { -10, 95000, "Квентин", "StaticFiles/images/10.jpg", "Тарантино" },
                    { -2, 127000, "Райан", "StaticFiles/images/2.jpg", "Рейнольдс" }
                });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "Id", "AddedTime", "ContentId", "ContentType" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(5368), 1, 1 },
                    { 2, new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(5811), 2, 1 },
                    { 4, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 5, new DateTime(2018, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0 },
                    { 3, new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(5828), 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "фантастика" },
                    { 3, "триллер" },
                    { 4, "боевик" },
                    { 5, "приключения" },
                    { 6, "детектив" },
                    { 7, "комедия" },
                    { 8, "ужасы" },
                    { 2, "драма" }
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "JobTitleId", "JobName" },
                values: new object[,]
                {
                    { 4, "продюсер" },
                    { 5, "оператор" },
                    { 6, "композитор" },
                    { 1, "актер" },
                    { 3, "сценарист" },
                    { 2, "режиссер" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ImageSource", "Rate", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "StaticFiles/images/Aeronauts.jpg", 5, 2019, "Аэронавты" },
                    { 2, "StaticFiles/images/1917.jpg", 5, 2019, "1917" },
                    { 3, "StaticFiles/images/JumanjiNL.jpg", 5, 2019, "Джуманджи: Новый уровень" },
                    { 4, "StaticFiles/images/Banker.jpg", 5, 2020, "Банкир" },
                    { 5, "StaticFiles/images/SonikH.jpg", 5, 2020, "Соник в кино" },
                    { 6, "StaticFiles/images/PreyBirdsHQ.jpg", 5, 2020, "Хищные птицы: Потрясающая история Харли Квинн" },
                    { 8, "StaticFiles/images/Composer.jpg", 5, 2019, "Композитор" },
                    { 7, "StaticFiles/images/LittleWomen.jpg", 5, 2019, "Маленькие женщины" }
                });

            migrationBuilder.InsertData(
                table: "Serials",
                columns: new[] { "Id", "Name", "PosterImageSource", "Rating", "Year" },
                values: new object[,]
                {
                    { 1, "Видоизменённый углерод (1-2 сезон)", "StaticFiles/images/11.jpg", 3.0, 2018 },
                    { 2, "Викинги (1-6 сезон)", "StaticFiles/images/12.jpg", 4.0, 2013 },
                    { 3, "Ведьмак (1 сезон)", "StaticFiles/images/13.jpg", 5.0, 2019 },
                    { 4, "Чужак (1 сезон)", "StaticFiles/images/14.jpg", 5.0, 2020 },
                    { 5, "Маленькая Америка (1 сезон)", "StaticFiles/images/15.jpg", 5.0, 2020 },
                    { 6, "Пятая авеню (1 сезон)", "StaticFiles/images/16.jpg", 5.0, 2020 },
                    { 7, "Звёздный путь: Пикар (1 сезон)", "StaticFiles/images/17.jpg", 5.0, 2020 },
                    { 8, "Замок и ключ (1 сезон)", "StaticFiles/images/18.jpg", 5.0, 2020 },
                    { 9, "Hi-Fi / Фанатик (1 сезон)", "StaticFiles/images/19.jpg", 5.0, 2020 },
                    { 10, "Разрабы (1 сезон)", "StaticFiles/images/20.jpg", 5.0, 2020 },
                    { 11, "Охотники (1 сезон)", "StaticFiles/images/21.jpg", 5.0, 2020 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "UserName", "UserPassword" },
                values: new object[] { 1, "garik@gmail.com", "Garik", "1234556" });

            migrationBuilder.InsertData(
                table: "ActorsLists",
                columns: new[] { "MovieId", "ActorId" },
                values: new object[,]
                {
                    { 8, 36 },
                    { 4, 15 },
                    { 4, 14 },
                    { 4, 13 },
                    { 3, 40 },
                    { 3, 12 },
                    { 3, 11 },
                    { 3, 10 },
                    { 3, 9 },
                    { 4, 16 },
                    { 2, 39 },
                    { 2, 6 },
                    { 2, 5 },
                    { 1, 38 },
                    { 1, 37 },
                    { 1, 4 },
                    { 1, 3 },
                    { 1, 2 },
                    { 1, 1 },
                    { 2, 7 },
                    { 4, 17 },
                    { 2, 8 },
                    { 5, 18 },
                    { 4, 41 },
                    { 8, 34 },
                    { 8, 33 },
                    { 8, 32 },
                    { 7, 43 },
                    { 7, 31 },
                    { 7, 30 },
                    { 7, 29 },
                    { 7, 28 },
                    { 7, 27 },
                    { 8, 35 },
                    { 6, 26 },
                    { 5, 20 },
                    { 5, 21 },
                    { 5, 22 },
                    { 5, 19 },
                    { 6, 23 },
                    { 6, 24 },
                    { 6, 25 },
                    { 5, 42 }
                });

            migrationBuilder.InsertData(
                table: "CelebrityJobTitles",
                columns: new[] { "CelebrityId", "JobTitleId" },
                values: new object[,]
                {
                    { -2, 1 },
                    { -7, 2 },
                    { -3, 1 },
                    { -4, 1 },
                    { -5, 1 },
                    { -6, 1 },
                    { -7, 1 },
                    { -10, 1 },
                    { -4, 2 },
                    { -10, 2 },
                    { -3, 4 },
                    { -10, 3 },
                    { -2, 4 },
                    { -1, 1 },
                    { -4, 4 },
                    { -5, 4 },
                    { -6, 4 },
                    { -7, 4 },
                    { -10, 4 },
                    { -9, 6 },
                    { -7, 3 },
                    { -8, 5 }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "AuthorId", "Content", "CountViews", "PreviewImage", "PublishTime", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis ea veritatis voluptates veniam sunt unde quibusdam modi laboriosam deleniti quod, minima vero nobis! Cumque natus ipsum ab incidunt qui corrupti quis, sit, voluptas, nisi reprehenderit itaque reiciendis. Quo optio itaque minima in numquam officiis odit minus tempora ut error cumque magni voluptate velit rem ullam quidem maiores esse, sint nostrum aliquid, explicabo at! Aspernatur quibusdam consequuntur officia quasi molestiae doloribus sed quaerat mollitia pariatur eius distinctio nesciunt ratione sunt vitae recusandae illum, voluptatibus sit atque consequatur facere aliquam. Itaque eos, atque excepturi illo soluta consectetur, amet minus reiciendis, ipsa velit dignissimos quidem quo doloremque adipisci sed ratione quae minima aut? Inventore est rerum libero, corrupti, id impedit molestiae excepturi omnis facere fugiat iste a amet, earum necessitatibus dolores delectus molestias voluptatem voluptates odio. Nulla, soluta! Quod ex veniam nihil nobis consequuntur repellendus expedita eligendi cumque rem, modi itaque asperiores incidunt eos velit placeat sint dolores. Incidunt cupiditate, alias dolor officia accusantium sed eius doloremque voluptatibus nesciunt nam, ipsum, soluta culpa quod quam possimus? Dolore quasi, dignissimos quam tenetur delectus unde velit, expedita excepturi laboriosam est, consectetur cumque reiciendis facilis nemo similique ea pariatur suscipit repellendus dolor? Pariatur libero cupiditate sint.", 233, "StaticFiles/images/News/1.jfif", new DateTime(2020, 12, 16, 23, 2, 22, 510, DateTimeKind.Local).AddTicks(1854), "Сиквел «Чудо-женщины» перенесли из-за коронавируса" },
                    { 4, 1, "«Фильм Про» впервые обнародовал Абсолютный топ продаж российских онлайн-кинотеатров и видеосервисов. В условиях, когда из-за коронавируса домашний просмотр набирает популярность, «Фильм Про» первым среди профессиональных киноизданий ", 878, "StaticFiles/images/News/4.jfif", new DateTime(2020, 12, 16, 23, 2, 22, 512, DateTimeKind.Local).AddTicks(6777), "Фильмы онлайн: Абсолютный топ «Фильм Про»" },
                    { 2, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis ea veritatis voluptates veniam sunt unde quibusdam modi laboriosam deleniti quod, minima vero nobis! Cumque natus ipsum ab incidunt qui corrupti quis, sit, voluptas, nisi reprehenderit itaque reiciendis. Quo optio itaque minima in numquam officiis odit minus tempora ut error cumque magni voluptate velit rem ullam quidem maiores esse, sint nostrum aliquid, explicabo at! Aspernatur quibusdam consequuntur officia quasi molestiae doloribus sed quaerat mollitia pariatur eius distinctio nesciunt ratione sunt vitae recusandae illum, voluptatibus sit atque consequatur facere aliquam. Itaque eos, atque excepturi illo soluta consectetur, amet minus reiciendis, ipsa velit dignissimos quidem quo doloremque adipisci sed ratione quae minima aut? Inventore est rerum libero, corrupti, id impedit molestiae excepturi omnis facere fugiat iste a amet, earum necessitatibus dolores delectus molestias voluptatem voluptates odio. Nulla, soluta! Quod ex veniam nihil nobis consequuntur repellendus expedita eligendi cumque rem, modi itaque asperiores incidunt eos velit placeat sint dolores. Incidunt cupiditate, alias dolor officia accusantium sed eius doloremque voluptatibus nesciunt nam, ipsum, soluta culpa quod quam possimus? Dolore quasi, dignissimos quam tenetur delectus unde velit, expedita excepturi laboriosam est, consectetur cumque reiciendis facilis nemo similique ea pariatur suscipit repellendus dolor? Pariatur libero cupiditate sint.", 512, "StaticFiles/images/News/2.jfif", new DateTime(2020, 12, 16, 23, 2, 22, 512, DateTimeKind.Local).AddTicks(6705), "Childish Gambino официально опубликовал новый альбом" },
                    { 3, 3, "В Сети появился трейлер второго сезона анимационного сериала DС «Харли Квинн». В центре сюжета вновь окажется Харли Квинн и её команда антигероев. После того, как героиня... расстаётся с Джокером, она становится самостоятельной единицей преступного мира и наводит.Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis ea veritatis voluptates veniam sunt unde quibusdam modi laboriosam deleniti quod, minima vero nobis! Cumque natus ipsum ab incidunt qui corrupti quis, sit, voluptas, nisi reprehenderit itaque reiciendis. Quo optio itaque minima in numquam officiis odit minus tempora ut error cumque magni voluptate velit rem ullam quidem maiores esse, sint nostrum aliquid, explicabo at! Aspernatur quibusdam consequuntur officia quasi molestiae doloribus sed quaerat mollitia pariatur eius distinctio nesciunt ratione sunt vitae recusandae illum, voluptatibus sit atque consequatur facere aliquam. Itaque eos, atque excepturi illo soluta consectetur, amet minus reiciendis, ipsa velit dignissimos quidem quo doloremque adipisci sed ratione quae minima aut? Inventore est rerum libero, corrupti, id impedit molestiae excepturi omnis facere fugiat iste a amet, earum necessitatibus dolores delectus molestias voluptatem voluptates odio. Nulla, soluta! Quod ex veniam nihil nobis consequuntur repellendus expedita eligendi cumque rem, modi itaque asperiores incidunt eos velit placeat sint dolores. Incidunt cupiditate, alias dolor officia accusantium sed eius doloremque voluptatibus nesciunt nam, ipsum, soluta culpa quod quam possimus? Dolore quasi, dignissimos quam tenetur delectus unde velit, expedita excepturi laboriosam est, consectetur cumque reiciendis facilis nemo similique ea pariatur suscipit repellendus dolor? Pariatur libero cupiditate sint.", 237, "StaticFiles/images/News/3.jfif", new DateTime(2020, 12, 16, 23, 2, 22, 512, DateTimeKind.Local).AddTicks(6771), "Больше, жестче, грубее: Вышел трейлер второго сезона «Харли Квинн»" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ActorsRating", "ContentType", "DirectingRating", "FilmId", "PlotRating", "PublishTime", "ReviewContent", "ReviewTitle", "SpectacleRating", "UserId" },
                values: new object[,]
                {
                    { 1, 1.5f, 1, 2f, 1, 1f, new DateTime(2020, 12, 16, 23, 2, 22, 513, DateTimeKind.Local).AddTicks(8737), "Фильм повествует о 4-х сестрах: Мег (Эмма Уотсон), Джо (Сирша Ронан), Бет (Элайза Сканлен) и Эми(Флоренс Пью).Каждая из сестер имеет свой необычныйхарактер,и каждая мне полюбилась по своему.Самая старшая и женственная Мег, видно какой она серьезной бывает, думая о своем будущем и заботясь о сестренках. Джо — с мальчишеским характером и духом писателя,эта девушка прямолинейна и может  высказать своему собеседнику все что думает о нем.Явно отличается от своих сестер, а что самое интересное, для того времени совсем не думает о замужестве) Считая, чтоженщина вполне сама себя может обеспечить.Бет — скромная и тихая девушка, она любитмузыку и когда играет на фортепиано, все затихают, дабы послушать ее", "Очень черное зеркало", 4f, 1 },
                    { 2, 1.3f, 1, 3f, 2, 4f, new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(714), "Для меня сериал стал неким открытием в мире современного кинематографа. Необычный сюжет, неожиданный поворот событий, умение держать зрителя в напряжении, экскурсы в историю - всё это, безусловно, дополняется шикарным актёрским составом, качественной картинкой и идеально подобранной музыкой. Из минусов, пожалуй тот факт что сериал будет тяжелым для некоторых людей, особенно для впечатлительных и оптимистов, а так же смерть некоторых основных персонажей. Лично меня больше всего в этом продукте привлекает две вещи: жестокий реализм,так как сейчас выпускают по сути розовое говно (извините за выражение), где много чего", "Острые козырьки", 1f, 1 },
                    { 3, 0.5f, 0, 2f, 3, 1f, new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(867), "Фильм повествует о 4-х сестрах: Мег (Эмма Уотсон), Джо (Сирша Ронан), Бет (Элайза Сканлен) и Эми(Флоренс Пью).Каждая из сестер имеет свой необычныйхарактер,и каждая мне полюбилась по своему.Самая старшая и женственная Мег, видно какой она серьезной бывает, думая о своем будущем и заботясь о сестренках. Джо — с мальчишеским характером и духом писателя,эта девушка прямолинейна и может  высказать своему собеседнику все что думает о нем.Явно отличается от своих сестер, а что самое интересное, для того времени совсем не думает о замужестве) Считая, чтоженщина вполне сама себя может обеспечить.Бет — скромная и тихая девушка, она любитмузыку и когда играет на фортепиано, все затихают, дабы послушать ее", "Безумный профессор", 1f, 1 },
                    { 4, 2.6f, 0, 1.6f, 4, 3f, new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(932), "Фильм повествует о 4-х сестрах: Мег (Эмма Уотсон), Джо (Сирша Ронан), Бет (Элайза Сканлен) и Эми(Флоренс Пью).Каждая из сестер имеет свой необычныйхарактер,и каждая мне полюбилась по своему.Самая старшая и женственная Мег, видно какой она серьезной бывает, думая о своем будущем и заботясь о сестренках. Джо — с мальчишеским характером и духом писателя,эта девушка прямолинейна и может  высказать своему собеседнику все что думает о нем.Явно отличается от своих сестер, а что самое интересное, для того времени совсем не думает о замужестве) Считая, чтоженщина вполне сама себя может обеспечить.Бет — скромная и тихая девушка, она любитмузыку и когда играет на фортепиано, все затихают, дабы послушать ее", "Безумный профессор", 5f, 1 },
                    { 5, 2.6f, 0, 1.6f, 5, 3f, new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(998), "Фильм повествует о 4-х сестрах: Мег (Эмма Уотсон), Джо (Сирша Ронан), Бет (Элайза Сканлен) и Эми(Флоренс Пью).Каждая из сестер имеет свой необычныйхарактер,и каждая мне полюбилась по своему.Самая старшая и женственная Мег, видно какой она серьезной бывает, думая о своем будущем и заботясь о сестренках. Джо — с мальчишеским характером и духом писателя,эта девушка прямолинейна и может  высказать своему собеседнику все что думает о нем.Явно отличается от своих сестер, а что самое интересное, для того времени совсем не думает о замужестве) Считая, чтоженщина вполне сама себя может обеспечить.Бет — скромная и тихая девушка, она любитмузыку и когда играет на фортепиано, все затихают, дабы послушать ее", "Аэронафтика как смысл жизни", 5f, 1 },
                    { 6, 2.6f, 0, 1.6f, 5, 3f, new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(1059), "Фильм повествует о 4-х сестрах: Мег (Эмма Уотсон), Джо (Сирша Ронан), Бет (Элайза Сканлен) и Эми(Флоренс Пью).Каждая из сестер имеет свой необычныйхарактер,и каждая мне полюбилась по своему.Самая старшая и женственная Мег, видно какой она серьезной бывает, думая о своем будущем и заботясь о сестренках. Джо — с мальчишеским характером и духом писателя,эта девушка прямолинейна и может  высказать своему собеседнику все что думает о нем.Явно отличается от своих сестер, а что самое интересное, для того времени совсем не думает о замужестве) Считая, чтоженщина вполне сама себя может обеспечить.Бет — скромная и тихая девушка, она любитмузыку и когда играет на фортепиано, все затихают, дабы послушать ее", "Очень черное зеркало", 5f, 1 }
                });

            migrationBuilder.InsertData(
                table: "SerialCelebrities",
                columns: new[] { "SerialId", "CelebrityId" },
                values: new object[,]
                {
                    { 11, -9 },
                    { 9, -9 },
                    { 4, -1 },
                    { 4, -2 },
                    { 4, -3 },
                    { 5, -4 },
                    { 5, -5 },
                    { 10, -9 },
                    { 6, -7 },
                    { 5, -6 },
                    { 11, -8 },
                    { 6, -9 },
                    { 7, -9 },
                    { 8, -9 },
                    { 9, -8 },
                    { 8, -8 },
                    { 10, -8 },
                    { 6, -8 },
                    { 11, -7 },
                    { 10, -7 },
                    { 9, -7 },
                    { 8, -7 },
                    { 7, -7 },
                    { 7, -8 }
                });

            migrationBuilder.InsertData(
                table: "SerialGenreTitles",
                columns: new[] { "SerialId", "GenreId" },
                values: new object[,]
                {
                    { 3, 5 },
                    { 4, 5 },
                    { 4, 4 },
                    { 4, 2 },
                    { 3, 4 },
                    { 1, 1 },
                    { 2, 5 },
                    { 2, 4 },
                    { 2, 2 },
                    { 1, 3 },
                    { 1, 2 },
                    { 5, 2 },
                    { 3, 2 },
                    { 5, 4 },
                    { 7, 4 },
                    { 6, 2 },
                    { 11, 5 },
                    { 11, 4 },
                    { 11, 2 },
                    { 10, 5 },
                    { 10, 2 },
                    { 9, 5 },
                    { 9, 4 },
                    { 9, 2 },
                    { 8, 5 },
                    { 8, 4 },
                    { 8, 2 },
                    { 7, 5 },
                    { 7, 2 },
                    { 6, 5 },
                    { 6, 4 },
                    { 5, 5 },
                    { 10, 4 }
                });

            migrationBuilder.InsertData(
                table: "NewsCategories",
                columns: new[] { "CategoryId", "NewsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 2 },
                    { 1, 2 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorsLists_ActorId",
                table: "ActorsLists",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_CelebrityJobTitles_JobTitleId",
                table: "CelebrityJobTitles",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_News_AuthorId",
                table: "News",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCategories_NewsId",
                table: "NewsCategories",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialCelebrities_CelebrityId",
                table: "SerialCelebrities",
                column: "CelebrityId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialGenreTitles_GenreId",
                table: "SerialGenreTitles",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorsLists");

            migrationBuilder.DropTable(
                name: "CelebrityJobTitles");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "NewsCategories");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SerialCelebrities");

            migrationBuilder.DropTable(
                name: "SerialGenreTitles");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Celebrities");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Serials");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
