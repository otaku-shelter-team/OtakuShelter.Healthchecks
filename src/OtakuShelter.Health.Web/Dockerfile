FROM microsoft/dotnet:2.2-sdk AS build
COPY . /otakushelter/health/service
WORKDIR /otakushelter/health/service/src/OtakuShelter.Health.Web
RUN dotnet publish -c Release -o artifacts

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /otakushelter/health/service
COPY --from=build /otakushelter/health/service/src/OtakuShelter.Health.Web/artifacts ./
ENTRYPOINT ["dotnet", "OtakuShelter.Health.Web.dll"] 