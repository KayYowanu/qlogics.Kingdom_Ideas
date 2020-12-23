/*  
Create qlogicsKingdom_Ideas table
*/

CREATE TABLE [dbo].[qlogicsKingdom_Ideas](
	[Kingdom_IdeasId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_qlogicsKingdom_Ideas] PRIMARY KEY CLUSTERED 
  (
	[Kingdom_IdeasId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[qlogicsKingdom_Ideas] WITH CHECK ADD CONSTRAINT [FK_qlogicsKingdom_Ideas_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO