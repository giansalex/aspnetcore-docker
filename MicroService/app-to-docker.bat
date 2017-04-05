rd /s /q obj\docker
dotnet publish -c release -o ./obj/docker
copy Dockerfile obj\docker\
cd obj/docker
docker build -t imm/microservice:1.0 .
pause 