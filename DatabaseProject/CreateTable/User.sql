/*
В базе данных должна быть предусмотрена файловая группа MEMORY_OPTIMIZED_DATA,
чтобы можно было создать оптимизированный для памяти объект.

Число сегментов должно быть задано как примерно в два раза 
превышающее максимально ожидаемое количество уникальных значений в 
ключе индекса с округлением до ближайшего четного числа.
*/

CREATE TABLE [dbo].[Users]
(
	[id] INT NOT NULL PRIMARY KEY NONCLUSTERED HASH WITH (BUCKET_COUNT = 131072), 
    [login] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL
) WITH (MEMORY_OPTIMIZED = ON)