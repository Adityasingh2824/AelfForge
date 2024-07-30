import os
import subprocess
import re
import ast

def scan_contracts(project_dir):
    """Scans contracts for potential vulnerabilities and code smells."""
    for root, _, files in os.walk(project_dir):
        for file in files:
            if file.endswith(".cs"):
                filepath = os.path.join(root, file)
                with open(filepath, "r") as f:
                    code = f.read()
                    
                    # Vulnerability patterns
                    if re.search(r"Assert\(Context\.Sender == State\.Owner\.Value", code):
                        print(f"Potential owner-only vulnerability in {filepath}")
                    
                    # Code smell patterns (example)
                    if re.search(r"public \w+ \w+\(", code):
                        print(f"Consider using private functions in {filepath}")

                    # AST-based analysis (example)
                    tree = ast.parse(code)
                    for node in ast.walk(tree):
                        if isinstance(node, ast.FunctionDef):
                            if len(node.args.args) > 5:
                                print(f"Function {node.name} in {filepath} has too many arguments (potential code smell)")
                    
def main():
    # Replace with your project directory
    project_dir = "your_project_directory" 
    
    scan_contracts(project_dir)

if __name__ == "__main__":
    main()
