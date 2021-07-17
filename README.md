# EBookPresenter

This is an app that looks at the path provided in the appsettings.json and presents all .epub files for download.

It can be sorted by either file creation date or alphabetically.

There are two docker-files. One that builds the solution before creating the finalized docker that is to be run and the other that only creates a docker container from the compiled code.

If you have Visual Studio installed you can just publish the code to a folder and then run the docker command from there.
If you don't have a development environment use the docker file that also compiles the code and then builds a resulting container for use. Don't forget to remove the dotnet core sdk container after building as it's pretty large.

## Docker scripts

There are 3 docker scripts written in python (3) under ~/src/EBookPresenter/docker/.

buildDocker.py builds the image.
runDocker.py runs the image with the correct parameters.
cleanDocker.py removes container and image.

There are 3 config files.

`name` describes the name of the image/container (e.g. ebookpresenter).
`release` describes the release of the image/container (e.g. 0.0.1-rc1).
`mount` describes the path on the host to map to the internal /books/ in the container (e.g. /mnt/c/temp).
