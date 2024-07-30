import os
import subprocess

def create_project(project_name):
    """Creates a new aelf forge project directory with basic structure."""
    os.makedirs(project_name, exist_ok=True)
    with open(os.path.join(project_name, "aelf.json"), "w") as f:
        # Write basic aelf project configuration (replace with your actual configuration)
        f.write("""{
            "name": "%s",
            "version": "1.0.0",
            // ... other configurations
        }""" % project_name)

def compile_contracts(project_dir):
    """Compiles smart contracts within the project directory."""
    # Replace with the actual aelf compilation command
    subprocess.run(["aelf-compiler", "--project-dir", project_dir])

def deploy_contracts(project_dir):
    """Deploys compiled contracts to the aelf blockchain."""
    # Replace with the actual aelf deployment command
    subprocess.run(["aelf-deploy", "--project-dir", project_dir])

if __name__ == "__main__":
    import argparse

    parser = argparse.ArgumentParser(description="aelf forge project scaffolding tool")
    parser.add_argument("project_name", help="Name of the new project")
    parser.add_argument("--compile", action="store_true", help="Compile contracts")
    parser.add_argument("--deploy", action="store_true", help="Deploy contracts")
    args = parser.parse_args()

    create_project(args.project_name)

    if args.compile:
        compile_contracts(args.project_name)
    if args.deploy:
        deploy_contracts(args.project_name)
