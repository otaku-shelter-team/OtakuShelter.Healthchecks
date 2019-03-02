FROM microsoft/dotnet:2.2-sdk AS build
COPY . /otakushelter/healthchecks/service
WORKDIR /otakushelter/healthchecks/service/src/OtakuShelter.Healthchecks.Web
RUN dotnet publish -c Release -o artifacts

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /otakushelter/healthchecks/service
COPY --from=build /otakushelter/healthchecks/service/src/OtakuShelter.Healthchecks.Web/artifacts ./
ENTRYPOINT ["dotnet", "OtakuShelter.Healthchecks.Web.dll"] 