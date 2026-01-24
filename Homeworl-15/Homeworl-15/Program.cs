using Homeworl_15;

var fileManager = new FileManager();

var inputPath = fileManager.GetInputFilePath();
var outputPath = fileManager.GetOutputFilePath();
fileManager.CopyFileUsingStream(inputPath, outputPath);
