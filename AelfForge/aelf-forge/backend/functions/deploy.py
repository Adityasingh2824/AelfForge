import subprocess
import argparse
import json

def deploy_contracts(project_dir, account_address, password):
    """Deploys contracts from the specified project directory."""

    # Compile the contracts (replace with your actual compilation command)
    subprocess.run(["aelf-compiler", "--project-dir", project_dir])

    with open(os.path.join(project_dir, "aelf.json")) as f:
        config = json.load(f)
        contracts = config.get("contracts", {})

    for contract_name, contract_info in contracts.items():
        contract_path = os.path.join(project_dir, contract_info["path"])

        # Deploy the contract (replace with your actual deployment command)
        subprocess.run([
            "aelf-command", "deploy",
            "--account", account_address,
            "--password", password,
            "--contract-path", contract_path
        ])

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="aelf forge contract deployment script")
    parser.add_argument("project_dir", help="Path to the project directory")
    parser.add_argument("--account", required=True, help="Account address to use for deployment")
    parser.add_argument("--password", required=True, help="Password for the account")

    args = parser.parse_args()

    deploy_contracts(args.project_dir, args.account, args.password)
