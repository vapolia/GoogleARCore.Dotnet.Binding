var TARGET = Argument ("t", Argument ("target", "nuget"));

var NUGET_VERSION = Argument<string>("nugetVersion", "1.45.0");
var AAR_VERSION = "1.45.0";
var OBJ_VERSION = "0.4.0";

var AAR_URL = string.Format("https://dl.google.com/dl/android/maven2/com/google/ar/core/{0}/core-{0}.aar", AAR_VERSION);
var OBJ_URL = string.Format("https://oss.sonatype.org/content/repositories/releases/de/javagl/obj/{0}/obj-{0}.jar", OBJ_VERSION);

Task ("externals")
	.Does (() =>
{
	var AAR_FILE = string.Format("./externals/arcore-{0}.aar", AAR_VERSION);
	var OBJ_JAR_FILE = string.Format("./externals/obj-{0}.jar", OBJ_VERSION);;

	if (!DirectoryExists ("./externals/"))
		CreateDirectory ("./externals");

	if (!FileExists (AAR_FILE))
	{
		DownloadFile (AAR_URL, AAR_FILE);
		if(FileExists ("./externals/arcore.aar"))
			DeleteFile("./externals/arcore.aar");
		CopyFile(AAR_FILE, "./externals/arcore.aar");
	}

	if (!FileExists (OBJ_JAR_FILE))
	{
		DownloadFile (OBJ_URL, OBJ_JAR_FILE);
		if(FileExists ("./externals/obj.aar"))
			DeleteFile("./externals/obj.aar");
		CopyFile(OBJ_JAR_FILE, "./externals/obj.jar");
	}
});

Task("libs")
	.IsDependentOn("externals")
	.Does(() =>
{
	DotNetBuild("./ARCore.sln", new DotNetBuildSettings {
		Configuration = "Release"
	});
});

Task("nuget")
	.IsDependentOn("libs")
	.Does(() =>
{
	var dotnetPackSettings = new DotNetPackSettings {
        Configuration            = "Release",
		OutputDirectory          = "./output",
        MSBuildSettings = new DotNetMSBuildSettings {
          PackageVersion = NUGET_VERSION,
          Version = NUGET_VERSION,
       }
	};

	DotNetPack("./ARCore.sln", dotnetPackSettings);
});

Task ("clean")
	.Does (() =>
{
	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", new DeleteDirectorySettings { Force=true });
});

RunTarget (TARGET);
