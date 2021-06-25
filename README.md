# Uta95s-Movie-Website
- Thong Nhat Link Data: 
    - Images: F:\Data\Image
- Example: 
    - Video:  F:\Data\Video
    

--- Insert Into query with Binary Object    
 
INSERT INTO dbo.DEMOBO
        ( name, images, videoLink, date )
VALUES  ( 
          N'Test', -- name - nvarchar(max)
          (SELECT * FROM OPENROWSET(BULK N'F:\Data\Images\Naruto-Form.png', SINGLE_BLOB) images), -- images - varbinary(max)
          (SELECT * FROM OPENROWSET(BULK N'F:\Data\Movie\Tinder.mp4', SINGLE_BLOB) videoLink), -- videoLink - varbinary(max)
          GETDATE()  -- date - datetime
          )


--- Insert Into query in Coding

INSERT INTO dbo.DEMOBO ( name, images, videoLink, [date] ) VALUES  ( N'Test2', NULL, NULL, GETDATE())
DELETE dbo.MOVIES WHERE MID = 1
