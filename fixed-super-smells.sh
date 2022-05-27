#!/bin/bash

# smells to run
SMELLS=('super-smell')
# variants to run for each smell
VARIANTS=('dead-local-store' 'duplicate-code' 'feature-envy' 'parameter-by-value' 'repeated-conditionals' 'self-assignment' 'short-circuit'
           'type-checking' 'dead-code' 'redundant-data-storage' 'in-line' ''
           'dead-local-store duplicate-code feature-envy parameter-by-value repeated-conditionals self-assignment short-circuit type-checking dead-code redundant-data-storage in-line' 'feature-envy parameter-by-value' 'feature-envy duplicate-code' 'feature-envy repeated-conditionals' 'feature-envy short-circuit' 'parameter-by-value duplicate code' 'parameter-by-value repeated-conditionals' 'parameter-by-value short-circuit' 'duplicate-code repeated-conditionals' 'duplicate-code short-circuit' 'repeated-conditionals short-circuit' 'feature-envy parameter-by-value duplicate-code' 'feature-envy parameter-by-value repeated-conditionals' 'feature-envy parameter-by-value short-circuit' 'feature-envy duplicate-code repeated-conditionals' 'feature-envy duplicate-code repeated-conditionals' 'feature-envy duplicate-code short-circuit' 'feature-envy repeated-conditionals short-circuit' 'parameter-by-value duplicate-code repeated-conditionals' 'parameter-by-value duplicate-code short-circuit' 'parameter-by-value repeated-conditionals short-circuit' 'duplicate-code repeated-conditionals short-circuit' 'feature-envy parameter-by-value duplicate-code repeated-conditionals' 'feature-envy parameter-by-value duplicate-code short-circuit' 'feature-envy parameter-by-value repeated-conditionals short-circuit' 'feature-envy duplicate-code repeated-conditionals short-circuit' 'parameter-by-value duplicate-code repeated-conditionals short-circuit' 'feature-envy parameter-by-value duplicate-code repeated-conditionals short-circuit'
           )
# number of times to run each variant of each smell
N=400

# time (in seconds) to sleep between each benchmark - that is, between each variant
SLEEP=1

# absolute path of the supplied binary in the repo
SMELL_BINARY_PATH=`realpath "binary/Smells"`

# folder name of the current run - current time in seconds
NOW=`date +%s`
TWITCH=`realpath twitch.csv`
mkdir "$NOW"
cd "$NOW"

# run each smell
for smell in "${SMELLS[@]}"
do
    # make a dir for the current smell and move into it
    mkdir "${smell}"
    cd "${smell}"

    # run each variant
    for variant in "${VARIANTS[@]}"
    do
        # make a dir for the current variant and move into it
        mkdir "${variant}"
        cd "${variant}"

        # make a quick and dirty script for running the smell
        touch "run.sh"
        echo "#!/bin/bash" >> "run.sh"
        echo "${SMELL_BINARY_PATH} ${smell} ${variant}" >> "run.sh"
        chmod +x "run.sh"
        cp $TWITCH .

        RUN_PATH=`realpath "run.sh"`
        echo "Running code smell ${smell}, variant ${variant}"

        # run the benchmark
        # TODO: add -i with idle data immediately after "raplrs"
	raplrs -n "${smell}-${variant}" benchmark "$RUN_PATH" -n "${N}"
	echo "sudo raplrs -n "${smell}-${variant}" benchmark "$RUN_PATH" -n "${N}""

        # leave dir
        cd ..

        # sleep
        sleep "${SLEEP}"
    done

    # leave dir
    cd ..
done
