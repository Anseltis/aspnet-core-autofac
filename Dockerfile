# start from base
FROM microsoft/dotnet:latest
MAINTAINER Ansi

# install system-wide deps for python and node
COPY ConsoleApp1.sln /opt/ConsoleApp1.sln
COPY . /opt
RUN cd /opt

RUN dotnet restore
RUN dotnet run

WORKDIR /opt

