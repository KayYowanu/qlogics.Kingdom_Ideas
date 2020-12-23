/*  
Create qlogicsKingdomComment table
*/

CREATE TABLE [dbo].[qlogicsKingdomComments](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](256) NOT NULL,
	[PostId] [nvarchar](256) NOT NULL,
	[UserId] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[IsDeleted] [nvarchar](5) NULL,
	[DeletedOn] [datetime] NULL,
	[ModuleId] [int] NOT NULL,
  CONSTRAINT [PK_qlogicsComment_id] PRIMARY KEY CLUSTERED 
  (
	[CommentId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[qlogicsKingdomComments] WITH CHECK ADD CONSTRAINT [FK_qlogicsKingdomComments_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO