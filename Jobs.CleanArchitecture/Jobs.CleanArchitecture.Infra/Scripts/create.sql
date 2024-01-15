IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'dbo')
BEGIN
    EXEC('CREATE SCHEMA [dbo]');
END
GO;

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'status')
BEGIN
    CREATE TABLE [dbo].[status] (
        id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
        name INT,
        description VARCHAR(50)
    );
END
GO;

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'job')
BEGIN
    CREATE TABLE [dbo].[job] (
        id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
        title VARCHAR(50),
        description VARCHAR(50),
        location VARCHAR(50),
        salary DECIMAL(18, 2),
        id_status INT NOT NULL,
        FOREIGN KEY (id_status) REFERENCES [dbo].[status](id)
    );
END
GO;

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'user')
BEGIN
    CREATE TABLE [dbo].[user] (
        id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
        name VARCHAR(50),
        password VARCHAR(255),
        id_status INT NOT NULL,
        FOREIGN KEY (id_status) REFERENCES [dbo].[status](id)
    );
END
GO;

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'susbscribe')
BEGIN
    CREATE TABLE [dbo].[susbscribe] (
        id_job INT NOT NULL,
        id_user INT NOT NULL,
        date DATETIME,
        PRIMARY KEY (id_job, id_user),
        FOREIGN KEY (id_job) REFERENCES [dbo].[job](id),
        FOREIGN KEY (id_user) REFERENCES [dbo].[user](id)
    );
END
GO;

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'profile')
BEGIN
    CREATE TABLE [dbo].[profile] (
        id_user INT NOT NULL PRIMARY KEY,
        name INT,
        id_status INT NOT NULL,
        FOREIGN KEY (id_user) REFERENCES [dbo].[user](id),
        FOREIGN KEY (id_status) REFERENCES [dbo].[status](id)
    );
END
GO;

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'log')
BEGIN
    CREATE TABLE [dbo].[log] (
        id INT PRIMARY KEY IDENTITY(1,1),
        table_name VARCHAR(50) NOT NULL,
        column_name VARCHAR(50) NOT NULL,
        id_record INT NOT NULL,
        created_by VARCHAR(50) NOT NULL,
        created_on DATETIME NOT NULL,
        update_by VARCHAR(50),
        update_on DATETIME,
        delete_by VARCHAR(50),
        delete_on DATETIME
    );
END
GO;
