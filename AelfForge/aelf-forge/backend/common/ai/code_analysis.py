import os
import radon.complexity as cc
import lizard

def analyze_complexity(file_path):
    """Analyzes code complexity metrics."""
    with open(file_path, "r") as f:
        code = f.read()

    # Cyclomatic Complexity (using radon)
    cyclomatic_complexity = cc.cc_visit(code)

    # Maintainability Index (using radon)
    maintainability_index = cc.mi_visit(code, multi=True)  

    # Function Length and Complexity (using lizard)
    file_analysis = lizard.analyze_file(file_path)
    function_info = [
        {
            "name": func.name,
            "length": func.length,
            "cyclomatic_complexity": func.cyclomatic_complexity,
            "nloc": func.nloc,
        }
        for func in file_analysis.function_list
    ]

    return {
        "cyclomatic_complexity": cyclomatic_complexity,
        "maintainability_index": maintainability_index,
        "functions": function_info
    }

def scan_contracts(project_dir):
    """Scans contracts for code analysis."""
    for root, _, files in os.walk(project_dir):
        for file in files:
            if file.endswith(".cs"):
                filepath = os.path.join(root, file)
                analysis = analyze_complexity(filepath)
                print(f"Analysis for {filepath}:")
                print(f"  Cyclomatic Complexity: {analysis['cyclomatic_complexity']}")
                print(f"  Maintainability Index: {analysis['maintainability_index']}")
                print(f"  Functions:")
                for func in analysis["functions"]:
                    print(f"    - {func['name']}: length={func['length']}, complexity={func['cyclomatic_complexity']}, nloc={func['nloc']}")

if __name__ == "__main__":
    project_dir = "path/to/your/project"  # Replace with your actual project directory
    scan_contracts(project_dir)
