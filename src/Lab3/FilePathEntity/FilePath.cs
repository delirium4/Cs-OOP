namespace Itmo.ObjectOrientedProgramming.Lab4.FilePathEntity;

public class FilePath
{
   public FilePath(string? filePath)
   {
      if (filePath != null) DefineFilePath(filePath);
   }

   public string? AbsoluteFilePath { get; private set; }
   public string? RelativeFilePath { get; private set; }

   public void DefineFilePath(string filePath)
   {
      if (filePath != null && filePath[0] != '\\')
      {
         AbsoluteFilePath = filePath;
         RelativeFilePath = filePath.Substring(filePath.LastIndexOf('\\'));
      }
      else
      {
         RelativeFilePath = filePath;
      }
   }
}