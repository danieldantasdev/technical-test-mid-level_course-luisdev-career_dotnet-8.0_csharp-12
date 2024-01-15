CREATE TABLE [dbo].[job] (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    title VARCHAR(50),
    description VARCHAR(50),
    location VARCHAR(50),
    salary DECIMAL(18, 2),
    id_status INT,
    FOREIGN KEY (id_status) REFERENCES [dbo].[status](id)
);

GO;

CREATE TABLE [dbo].[status] (
    id INT NOT NULL PRIMARY KEY,
    name INT,
    description VARCHAR(50)
);
