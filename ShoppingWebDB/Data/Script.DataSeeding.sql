/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO Products(ProductName, Price, Photo) VALUES
('AK-47', 1999.99, 'ak47.jpg'),
('F-2000 Assault Rifle', 3000, 'F-2000-Assault-Rifle.jpg'),
('HK416 Assault Rifle', 500.50, 'Heckler-and-Koch-HK416-Assault-Rifle.jpg'),
('Mauser Model 98', 2131, 'mauser_model_98.jpg'),
('Remington', 8000, 'remington_model_1100.jpg'),
('Ruger Mark I', 699.99, 'ruger_mark_i.jpg'),
('Smith & Wesson Model 29', 499, 'smith_wesson_model_29.jpg'),
('Smith & Wesson Tripple Lock', 999, 'smith_wesson_tripple_lock.jpg'),
('Springfield Model 1903', 4000, 'springfield_model_1903.jpg'),
('Ultra Light Arms model 20', 2000, 'ultra_light_arms_model_20.jpg'),
('UZI', 2050, 'UZI-Machine-Gun.jpg');