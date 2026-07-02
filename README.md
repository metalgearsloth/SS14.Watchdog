# SS14.Watchdog 

SS14.Watchdog is SS14's server-hosting wrapper thing, similar to [TGS](https://github.com/tgstation/tgstation-server) for BYOND (but much simpler for the time being). It handles auto updates, monitoring, automatic restarts, and administration. We recommend you use this for proper deployments.

Documentation on how setup and use for SS14.Watchdog is [here](https://docs.spacestation14.io/en/getting-started/hosting#watchdog).

## Update providers

Each server instance chooses its own update provider with `Servers:Instances:<key>:UpdateType` and an optional `Updates` section. Different instances can use different providers.

### Manifest

Use `Manifest` when your publishing pipeline produces an SS14-style manifest. Watchdog fetches the manifest, chooses the newest build, selects the server artifact matching the host runtime identifier, verifies its SHA-256 hash, and applies it.

```yml
Servers:
  Instances:
    example:
      UpdateType: Manifest
      Updates:
        ManifestUrl: "https://example.invalid/fork/example/manifest"
        # Authentication:
        #   Username: "user"
        #   Password: "pass"
```

### Jenkins

Use `Jenkins` for legacy Jenkins publishing. Watchdog reads the job's last successful build and downloads `release/SS14.Server_<rid>.zip` from that build's artifacts.

```yml
Servers:
  Instances:
    example:
      UpdateType: Jenkins
      Updates:
        BaseUrl: "https://builds.example.invalid/jenkins"
        JobName: "SS14 Content"
```

### Git

Use `Git` for local development or hosts that intentionally build from source on the deployment machine. Watchdog clones/fetches the repository, resets to the configured branch, runs the repository packaging tools, and applies the produced server package. This requires Git, .NET, and sometimes Python on the host.

```yml
Servers:
  Instances:
    example:
      UpdateType: Git
      Updates:
        BaseUrl: "https://github.com/space-wizards/space-station-14.git"
        Branch: "master"
        HybridACZ: true
```

### Local

Use `Local` when another tool or an operator manages files in the instance directory. Watchdog only tracks the configured `CurrentVersion`; it does not copy server files.

```yml
Servers:
  Instances:
    example:
      UpdateType: Local
      Updates:
        CurrentVersion: "local-build-1"
```

### Dummy

Use `Dummy` only for tests or manual experiments. It always reports an update and advances the recorded revision without copying files.
