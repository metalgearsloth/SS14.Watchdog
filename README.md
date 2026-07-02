# SS14.Watchdog

SS14.Watchdog is SS14's server-hosting wrapper thing, similar to [TGS](https://github.com/tgstation/tgstation-server) for BYOND (but much simpler for the time being). It handles auto updates, monitoring, automatic restarts, and administration. We recommend you use this for proper deployments.

Documentation on how setup and use for SS14.Watchdog is [here](https://docs.spacestation14.io/en/getting-started/hosting#watchdog).

## Update providers

Each server instance chooses its own update provider with `Servers:Instances:<key>:UpdateType` and an optional `Updates` section. Different instances can use different providers.

### Manifest

Use `Manifest` when your publishing pipeline produces an SS14-style manifest. Watchdog fetches the manifest, chooses the newest build, validates, and applies it.

Properties:

| Property | Required | Description |
| --- | --- | --- |
| `ManifestUrl` | Yes | URL of the SS14 build manifest JSON. |
| `Authentication` | No | Basic auth credentials used when fetching the manifest and referenced artifacts. |
| `Authentication:Username` | No | Basic auth username. |
| `Authentication:Password` | No | Basic auth password. |

```yml
Servers:
  Instances:
    example:
      UpdateType: Manifest
      Updates:
        ManifestUrl: "https://example.com/fork/example/manifest"
        # Authentication:
        #   Username: "user"
        #   Password: "pass"
```

### Jenkins

Use `Jenkins` for Jenkins publishing. Watchdog reads the job's last successful build and downloads `release/SS14.Server_<rid>.zip` from that build's artifacts.

Properties:

| Property | Required | Description |
| --- | --- | --- |
| `BaseUrl` | Yes | Base URL of the Jenkins instance, without the job path. |
| `JobName` | Yes | Jenkins job name to query for the last successful build. |

```yml
Servers:
  Instances:
    example:
      UpdateType: Jenkins
      Updates:
        BaseUrl: "https://builds.example.com/jenkins"
        JobName: "SS14 Content"
```

### Git

Use `Git` for local development or hosts that intentionally build from source on the deployment machine. Watchdog clones/fetches the repository, resets to the configured branch, runs the repository packaging tools, and applies the produced server package.

Properties:

| Property | Required | Description |
| --- | --- | --- |
| `BaseUrl` | Yes | Git repository URL. This is the source repository URL, not watchdog's root `BaseUrl`. |
| `Branch` | No | Git branch to fetch, reset to, and package. Defaults to `master`. |
| `HybridACZ` | No | Builds a hybrid ACZ package when `true`. Defaults to `true`; set `false` when watchdog should host client binaries from `/instances/<key>/binaries`. |

```yml
Servers:
  Instances:
    example:
      UpdateType: Git
      Updates:
        BaseUrl: "https://github.com/space-wizards/space-station-14.git"
        Branch: "stable"
        HybridACZ: true
```

### Local

Use `Local` when another tool or an operator manages files in the instance directory. Watchdog only tracks the configured `CurrentVersion`; it does not copy server files.

Properties:

| Property | Required | Description |
| --- | --- | --- |
| `CurrentVersion` | Yes | Version string watchdog records as active. Change this after replacing local files externally to make watchdog restart into the new revision. |

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

Properties: none.
