
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/25/2017 21:07:57
-- Generated from EDMX file: K:\API\WatchIT\MovieAPI\MovieAPI\APIEntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MovieAPI];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MoviesLocal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocalSet] DROP CONSTRAINT [FK_MoviesLocal];
GO
IF OBJECT_ID(N'[dbo].[FK_MoviesTMDB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TMDBSet] DROP CONSTRAINT [FK_MoviesTMDB];
GO
IF OBJECT_ID(N'[dbo].[FK_MoviesYTS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[YTSSet] DROP CONSTRAINT [FK_MoviesYTS];
GO
IF OBJECT_ID(N'[dbo].[FK_YTStorrents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[torrentsSet] DROP CONSTRAINT [FK_YTStorrents];
GO
IF OBJECT_ID(N'[dbo].[FK_TMDBproduction_companies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[production_companiesSet] DROP CONSTRAINT [FK_TMDBproduction_companies];
GO
IF OBJECT_ID(N'[dbo].[FK_TMDBTMDBgenres]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TMDBgenresSet] DROP CONSTRAINT [FK_TMDBTMDBgenres];
GO
IF OBJECT_ID(N'[dbo].[FK_YTSYTSgenres]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[YTSgenresSet] DROP CONSTRAINT [FK_YTSYTSgenres];
GO
IF OBJECT_ID(N'[dbo].[FK_MoviesLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogSet] DROP CONSTRAINT [FK_MoviesLog];
GO
IF OBJECT_ID(N'[dbo].[FK_LogLogError]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogErrorSet] DROP CONSTRAINT [FK_LogLogError];
GO
IF OBJECT_ID(N'[dbo].[FK_LogLogSuccess]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogSuccessSet] DROP CONSTRAINT [FK_LogLogSuccess];
GO
IF OBJECT_ID(N'[dbo].[FK_LogInfoLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogInfoSet] DROP CONSTRAINT [FK_LogInfoLog];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TMDBSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TMDBSet];
GO
IF OBJECT_ID(N'[dbo].[MoviesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MoviesSet];
GO
IF OBJECT_ID(N'[dbo].[LocalSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocalSet];
GO
IF OBJECT_ID(N'[dbo].[torrentsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[torrentsSet];
GO
IF OBJECT_ID(N'[dbo].[TMDBgenresSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TMDBgenresSet];
GO
IF OBJECT_ID(N'[dbo].[YTSSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[YTSSet];
GO
IF OBJECT_ID(N'[dbo].[production_companiesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[production_companiesSet];
GO
IF OBJECT_ID(N'[dbo].[YTSgenresSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[YTSgenresSet];
GO
IF OBJECT_ID(N'[dbo].[LogSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogSet];
GO
IF OBJECT_ID(N'[dbo].[LogErrorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogErrorSet];
GO
IF OBJECT_ID(N'[dbo].[LogSuccessSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogSuccessSet];
GO
IF OBJECT_ID(N'[dbo].[LogInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogInfoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TMDBSet'
CREATE TABLE [dbo].[TMDBSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [adult] bit  NULL,
    [backdrop_path] nvarchar(max)  NULL,
    [budget] nvarchar(max)  NULL,
    [homepage] nvarchar(max)  NULL,
    [imdb_id] nvarchar(max)  NULL,
    [original_title] nvarchar(max)  NULL,
    [overview] nvarchar(max)  NULL,
    [popularity] nvarchar(max)  NULL,
    [poster_path] nvarchar(max)  NULL,
    [release_date] nvarchar(max)  NULL,
    [revenue] nvarchar(max)  NULL,
    [status] nvarchar(max)  NULL,
    [tagline] nvarchar(max)  NULL,
    [title] nvarchar(max)  NULL,
    [vote_average] nvarchar(max)  NULL,
    [vote_count] nvarchar(max)  NULL,
    [MoviesTMDB_TMDB_Id] int  NOT NULL
);
GO

-- Creating table 'MoviesSet'
CREATE TABLE [dbo].[MoviesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Guid] nvarchar(max)  NULL
);
GO

-- Creating table 'LocalSet'
CREATE TABLE [dbo].[LocalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Year] nvarchar(max)  NULL,
    [FileName] nvarchar(max)  NULL,
    [Location] nvarchar(max)  NULL,
    [Extension] nvarchar(max)  NULL,
    [Subtitle] nvarchar(max)  NULL,
    [Pixelsize] nvarchar(max)  NULL,
    [Format] nvarchar(max)  NULL,
    [Formatsize] nvarchar(max)  NULL,
    [Group] nvarchar(max)  NULL,
    [Error] nvarchar(max)  NULL,
    [MoviesLocal_Local_Id] int  NOT NULL
);
GO

-- Creating table 'torrentsSet'
CREATE TABLE [dbo].[torrentsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [url] nvarchar(max)  NULL,
    [hash] nvarchar(max)  NULL,
    [quality] nvarchar(max)  NULL,
    [seeds] bigint  NULL,
    [peers] bigint  NULL,
    [size] nvarchar(max)  NULL,
    [size_bytes] bigint  NULL,
    [date_uploaded] nvarchar(max)  NULL,
    [date_uploaded_unix] bigint  NULL,
    [YTStorrents_torrents_id] int  NOT NULL
);
GO

-- Creating table 'TMDBgenresSet'
CREATE TABLE [dbo].[TMDBgenresSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [TMDBTMDBgenres_TMDBgenres_id] int  NOT NULL
);
GO

-- Creating table 'YTSSet'
CREATE TABLE [dbo].[YTSSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [url] nvarchar(max)  NULL,
    [imdb_code] nvarchar(max)  NULL,
    [title] nvarchar(max)  NULL,
    [title_english] nvarchar(max)  NULL,
    [title_long] nvarchar(max)  NULL,
    [slug] nvarchar(max)  NULL,
    [year] int  NULL,
    [rating] float  NULL,
    [runtime] int  NULL,
    [summary] nvarchar(max)  NULL,
    [description_full] nvarchar(max)  NULL,
    [synopsis] nvarchar(max)  NULL,
    [yt_trailer_code] nvarchar(max)  NULL,
    [language] nvarchar(max)  NULL,
    [mpa_rating] nvarchar(max)  NULL,
    [background_image] nvarchar(max)  NULL,
    [background_image_original] nvarchar(max)  NULL,
    [small_cover_image] nvarchar(max)  NULL,
    [medium_cover_image] nvarchar(max)  NULL,
    [large_cover_image] nvarchar(max)  NULL,
    [state] nvarchar(max)  NULL,
    [date_uploaded] nvarchar(max)  NULL,
    [date_uploaded_unix] bigint  NULL,
    [MoviesYTS_YTS_Id] int  NOT NULL
);
GO

-- Creating table 'production_companiesSet'
CREATE TABLE [dbo].[production_companiesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [TMDBproduction_companies_production_companies_id] int  NOT NULL
);
GO

-- Creating table 'YTSgenresSet'
CREATE TABLE [dbo].[YTSgenresSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [YTSYTSgenres_YTSgenres_id] int  NOT NULL
);
GO

-- Creating table 'LogSet'
CREATE TABLE [dbo].[LogSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateTime] datetime  NOT NULL,
    [Movies_Id] int  NOT NULL
);
GO

-- Creating table 'LogErrorSet'
CREATE TABLE [dbo].[LogErrorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Error] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Log_Id] int  NOT NULL
);
GO

-- Creating table 'LogSuccessSet'
CREATE TABLE [dbo].[LogSuccessSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Log_Id] int  NOT NULL
);
GO

-- Creating table 'LogInfoSet'
CREATE TABLE [dbo].[LogInfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Info] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Log_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'TMDBSet'
ALTER TABLE [dbo].[TMDBSet]
ADD CONSTRAINT [PK_TMDBSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'MoviesSet'
ALTER TABLE [dbo].[MoviesSet]
ADD CONSTRAINT [PK_MoviesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocalSet'
ALTER TABLE [dbo].[LocalSet]
ADD CONSTRAINT [PK_LocalSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'torrentsSet'
ALTER TABLE [dbo].[torrentsSet]
ADD CONSTRAINT [PK_torrentsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TMDBgenresSet'
ALTER TABLE [dbo].[TMDBgenresSet]
ADD CONSTRAINT [PK_TMDBgenresSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'YTSSet'
ALTER TABLE [dbo].[YTSSet]
ADD CONSTRAINT [PK_YTSSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'production_companiesSet'
ALTER TABLE [dbo].[production_companiesSet]
ADD CONSTRAINT [PK_production_companiesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'YTSgenresSet'
ALTER TABLE [dbo].[YTSgenresSet]
ADD CONSTRAINT [PK_YTSgenresSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogSet'
ALTER TABLE [dbo].[LogSet]
ADD CONSTRAINT [PK_LogSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogErrorSet'
ALTER TABLE [dbo].[LogErrorSet]
ADD CONSTRAINT [PK_LogErrorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogSuccessSet'
ALTER TABLE [dbo].[LogSuccessSet]
ADD CONSTRAINT [PK_LogSuccessSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogInfoSet'
ALTER TABLE [dbo].[LogInfoSet]
ADD CONSTRAINT [PK_LogInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MoviesLocal_Local_Id] in table 'LocalSet'
ALTER TABLE [dbo].[LocalSet]
ADD CONSTRAINT [FK_MoviesLocal]
    FOREIGN KEY ([MoviesLocal_Local_Id])
    REFERENCES [dbo].[MoviesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MoviesLocal'
CREATE INDEX [IX_FK_MoviesLocal]
ON [dbo].[LocalSet]
    ([MoviesLocal_Local_Id]);
GO

-- Creating foreign key on [MoviesTMDB_TMDB_Id] in table 'TMDBSet'
ALTER TABLE [dbo].[TMDBSet]
ADD CONSTRAINT [FK_MoviesTMDB]
    FOREIGN KEY ([MoviesTMDB_TMDB_Id])
    REFERENCES [dbo].[MoviesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MoviesTMDB'
CREATE INDEX [IX_FK_MoviesTMDB]
ON [dbo].[TMDBSet]
    ([MoviesTMDB_TMDB_Id]);
GO

-- Creating foreign key on [MoviesYTS_YTS_Id] in table 'YTSSet'
ALTER TABLE [dbo].[YTSSet]
ADD CONSTRAINT [FK_MoviesYTS]
    FOREIGN KEY ([MoviesYTS_YTS_Id])
    REFERENCES [dbo].[MoviesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MoviesYTS'
CREATE INDEX [IX_FK_MoviesYTS]
ON [dbo].[YTSSet]
    ([MoviesYTS_YTS_Id]);
GO

-- Creating foreign key on [YTStorrents_torrents_id] in table 'torrentsSet'
ALTER TABLE [dbo].[torrentsSet]
ADD CONSTRAINT [FK_YTStorrents]
    FOREIGN KEY ([YTStorrents_torrents_id])
    REFERENCES [dbo].[YTSSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_YTStorrents'
CREATE INDEX [IX_FK_YTStorrents]
ON [dbo].[torrentsSet]
    ([YTStorrents_torrents_id]);
GO

-- Creating foreign key on [TMDBproduction_companies_production_companies_id] in table 'production_companiesSet'
ALTER TABLE [dbo].[production_companiesSet]
ADD CONSTRAINT [FK_TMDBproduction_companies]
    FOREIGN KEY ([TMDBproduction_companies_production_companies_id])
    REFERENCES [dbo].[TMDBSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TMDBproduction_companies'
CREATE INDEX [IX_FK_TMDBproduction_companies]
ON [dbo].[production_companiesSet]
    ([TMDBproduction_companies_production_companies_id]);
GO

-- Creating foreign key on [TMDBTMDBgenres_TMDBgenres_id] in table 'TMDBgenresSet'
ALTER TABLE [dbo].[TMDBgenresSet]
ADD CONSTRAINT [FK_TMDBTMDBgenres]
    FOREIGN KEY ([TMDBTMDBgenres_TMDBgenres_id])
    REFERENCES [dbo].[TMDBSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TMDBTMDBgenres'
CREATE INDEX [IX_FK_TMDBTMDBgenres]
ON [dbo].[TMDBgenresSet]
    ([TMDBTMDBgenres_TMDBgenres_id]);
GO

-- Creating foreign key on [YTSYTSgenres_YTSgenres_id] in table 'YTSgenresSet'
ALTER TABLE [dbo].[YTSgenresSet]
ADD CONSTRAINT [FK_YTSYTSgenres]
    FOREIGN KEY ([YTSYTSgenres_YTSgenres_id])
    REFERENCES [dbo].[YTSSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_YTSYTSgenres'
CREATE INDEX [IX_FK_YTSYTSgenres]
ON [dbo].[YTSgenresSet]
    ([YTSYTSgenres_YTSgenres_id]);
GO

-- Creating foreign key on [Movies_Id] in table 'LogSet'
ALTER TABLE [dbo].[LogSet]
ADD CONSTRAINT [FK_MoviesLog]
    FOREIGN KEY ([Movies_Id])
    REFERENCES [dbo].[MoviesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MoviesLog'
CREATE INDEX [IX_FK_MoviesLog]
ON [dbo].[LogSet]
    ([Movies_Id]);
GO

-- Creating foreign key on [Log_Id] in table 'LogErrorSet'
ALTER TABLE [dbo].[LogErrorSet]
ADD CONSTRAINT [FK_LogLogError]
    FOREIGN KEY ([Log_Id])
    REFERENCES [dbo].[LogSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LogLogError'
CREATE INDEX [IX_FK_LogLogError]
ON [dbo].[LogErrorSet]
    ([Log_Id]);
GO

-- Creating foreign key on [Log_Id] in table 'LogSuccessSet'
ALTER TABLE [dbo].[LogSuccessSet]
ADD CONSTRAINT [FK_LogLogSuccess]
    FOREIGN KEY ([Log_Id])
    REFERENCES [dbo].[LogSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LogLogSuccess'
CREATE INDEX [IX_FK_LogLogSuccess]
ON [dbo].[LogSuccessSet]
    ([Log_Id]);
GO

-- Creating foreign key on [Log_Id] in table 'LogInfoSet'
ALTER TABLE [dbo].[LogInfoSet]
ADD CONSTRAINT [FK_LogInfoLog]
    FOREIGN KEY ([Log_Id])
    REFERENCES [dbo].[LogSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LogInfoLog'
CREATE INDEX [IX_FK_LogInfoLog]
ON [dbo].[LogInfoSet]
    ([Log_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------