import argparse
import os

from aelf_tools import (
    create_project,
    compile_contracts,
    deploy_contracts,
    generate_contract,
    call_contract_method,
    get_contract_state,
    scan_contracts,
    analyze_comments,
    analyze_user_input,
    # ... import other functions as needed
)

from config import PROJECT_DIR, CONTRACT_DIR, TEMPLATE_DIR

def main():
    parser = argparse.ArgumentParser(description="aelf forge project management tool")

    # Project commands
    parser.add_argument("project_name", nargs="?", help="Name of the project")
    parser.add_argument("--create", action="store_true", help="Create a new project")
    parser.add_argument("--compile", action="store_true", help="Compile contracts")
    parser.add_argument("--deploy", action="store_true", help="Deploy contracts")
    parser.add_argument("--generate", metavar=("template", "contract"), nargs=2, 
                        help="Generate contract from template (e.g., 'voting MyVoting')")

    # Analysis commands
    parser.add_argument("--analyze-code", action="store_true", help="Analyze code complexity and style")
    parser.add_argument("--analyze-comments", action="store_true", help="Analyze comments in contracts")

    # Interaction commands
    parser.add_argument("--call", metavar=("contract", "method", "params"), nargs="+", 
                        help="Call a contract method (e.g., 'voting vote '{\"proposal_id\": 1, \"option\": \"yes\"}'')")
    parser.add_argument("--get-state", metavar=("contract", "variable"), nargs=2, 
                        help="Get a contract state variable (e.g., 'voting proposal_count')")

    args = parser.parse_args()

    # Project Creation
    if args.create:
        create_project(args.project_name, CONTRACT_DIR, TEMPLATE_DIR)

    # Compilation
    if args.compile:
        compile_contracts(args.project_name)

    # Deployment
    if args.deploy:
        deploy_contracts(args.project_name)

    # Contract Generation
    if args.generate:
        generate_contract(args.generate[0], args.generate[1])

    # Code Analysis
    if args.analyze_code:
        scan_contracts(CONTRACT_DIR)

    # Comment Analysis
    if args.analyze_comments:
        for file in os.listdir(CONTRACT_DIR):
            if file.endswith(".cs"):
                filepath = os.path.join(CONTRACT_DIR, file)
                print(f"Analysis for {filepath}: {analyze_comments(filepath)}")

    # Contract Interaction
    if args.call:
        contract_name, method_name, params_str = args.call[0], args.call[1], " ".join(args.call[2:])
        params = json.loads(params_str)
        result = call_contract_method(contract_name, method_name, params)
        print(result)

    if args.get_state:
        contract_name, variable_name = args.get_state
        result = get_contract_state(contract_name, variable_name)
        print(result)

if __name__ == "__main__":
    main()
