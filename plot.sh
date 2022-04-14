#!/bin/bash

# smells to plot
SMELLS=('dead-local-store' 'duplicate-code' 'feature-envy' 'god-class' 'long-method' 'parameter-by-value'
        'repeated-conditionals' 'self-assignment' 'short-circuit' 'type-checking-rtti' 'type-checking-type-field' 'redundant-data-storage' 'dead-code' 'in-line')

# first input param, base directory of results
BASE_DIR="$1"
OUTPUT_DIR="$1/__graph__"

if [[ ! -d data_analyzer/ ]]
then
    echo "Data analyzer repo not found in directory, performing base setup"

    git clone git@github.com:cs-21-pt-9-01/data_analyzer.git
    cd data_analyzer
    python -m venv venv
    source venv/bin/activate
    pip install matplotlib numpy

    echo ''
    echo "Please modify function 'translate_name' in file data_analyzer/analyzer/graph.py to include 'bad' and 'good' translations and run again"
    echo ''
    exit
fi

source data_analyzer/venv/bin/activate
mkdir "$OUTPUT_DIR"

for smell in "${SMELLS[@]}"
do
    python data_analyzer/run.py --input "$BASE_DIR/$smell" --graph grouped_barchart --title $smell --output "$OUTPUT_DIR/$smell"
done
