using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recog.PTests.D.Scales
{
    public static class NeuralNet
    {
     static double[] CrimeThresholds =
{

/* layer 1 */
1.1790187855668484, -0.041507545935835471, -0.31202097841014209, -2.6652825856229203,
0.63344596355679772, 1.4344844836756416,

/* layer 2 */
0.66266386361469576

};

static double[] CrimeWeights =
{

/* layer 1 */
1.0018788359751734, -0.41139351728498841, 0.49288358908551788, -1.1483564310279788,
0.61499180106167894, 0.11192629370423891, -1.3866459125183976, 1.6645967547962579,
-0.035941793422556809, -0.48699630491309059, -0.37397350363560244, -0.060445669552769372,
-1.5122746374349936, 0.26086794998112789, -0.73164064313445176, -0.79350720425174537,
0.2985745836119979, 0.3161404337306592,
1.0639958643106999, 0.41388735996594234, -1.6423096348196096, 1.4089253110683324,
-0.73093518310872196, 0.52662025499273235, 1.3362029159610429, 0.62297762447847815,
-2.5102207323168848, -0.29376608783842834, -1.7301463339261256, 1.6810569379279496,
0.23571257407685323, -0.73246288772391677, -1.548053951101299, 1.8331964011201907,
0.62131214747530694, -0.34194957507929469,
-1.443790573670751, -0.73319460924549851, 1.6421186867222772, -0.83514955877972086,
-0.013206466968484433, 0.13474527474880513, 0.36894877351634625, 0.2396272649684362,
-1.2929282210862605, -0.2184846443593384, 1.0603549377058414, 3.1446729545512522,
0.27185610138855221, -1.2891846543211687, -1.9941623900319614, 1.0156738216484622,
-0.39523912441285675, -0.42812334675844982,
1.3536611266174703, 0.95486053367093648, 0.094581710974144084, 0.377040548304581,
0.51117685200811191, -2.8081156597566883, -2.070549987526515, 0.43657351757684992,
-0.066735312380169179, 1.5467732524749578, -1.5055361708015653, -1.8680950032415098,
0.3328250426143548, -0.38955079915413865, 3.909293416383254, -2.6919308875405861,
0.72460637426437335, -1.3352062265613815,
-0.59643613281076446, 0.76066593797482118, 2.3586211754356508, -1.6839504356141639,
-1.9050300976371726, -1.0481022794625898, 3.9585574031516617, 1.089014625365766,
-0.38668563258538441, 2.050626831476686, -1.4309211240713202, 2.7723068686177137,
-0.55712150880301048, -0.87008484384306206, -3.2823672075452266, 2.8137587428738544,
-1.8280537314866341, -0.74077106702951867,
0.13013248903190872, 0.35353538959523134, -0.68027804655410629, 0.1793055584944579,
-0.81110575846859101, 0.88002186523049841, -0.31818706615173004, 0.97631647831260659,
-0.61778880369644362, -0.5010442063967101, -0.33354137732765871, -0.30776794244651168,
-0.12059791408747653, -2.179077641935216, 0.2635492084992716, -1.1076923924056086,
-0.2462690739145979, 2.0397763141159042,

/* layer 2 */
1.0317118711688165, -1.7130308914147228, -0.97755639279036199, 2.6735310406204835,
-2.2418251401653055, 1.7554676895702033

};

static double[] CrimeActs= new double[50];

/* ---------------------------------------------------------- */
/*
  CrimeRun - run neural network Crime

  Input and Output variables.
  Variable names are listed below in order, together with each
  variable's offset in the data set at the time code was
  generated (if the variable is then available).
  For nominal variables, the numeric code - class name
  conversion is shown indented below the variable name.
  To provide nominal inputs, use the corresponding numeric code.
  Input variables (Offset):
  edu (1)
    1=высшее
    2=базовое
    3=среднее
    4=средне-специальное
    5=средне-техническое
  Шкала первого уровня L(СБ) (2)
  Шкала первого уровня F(СБ) (3)
  Шкала первого уровня K(СБ) (4)
  Шкала первого уровня Hs(СБ) (5)
  Шкала первого уровня D(СБ) (6)
  Шкала первого уровня Hy(СБ) (7)
  Шкала первого уровня Pd(СБ) (8)
  Шкала первого уровня Mf(СБ) (9)
  Шкала первого уровня Pa(СБ) (10)
  Шкала первого уровня Pt(СБ) (11)
  Шкала первого уровня Sc(СБ) (12)
  Шкала первого уровня Ma(СБ) (13)
  Шкала первого уровня Si(СБ) (14)

  Выход:
  dang lev (0)
    1=1
    2=0

*/
/* ---------------------------------------------------------- */

private static void CrimeRun( double[] inputs, double[] outputs, int outputType )
{
  int i, k, u;
  double[] w = CrimeWeights, t = CrimeThresholds;

  /* Process inputs - apply pre-processing to each input in turn,
   * storing results in the neuron activations array.
   */

  /* One-of-N nominal pre-processing */
  if ( inputs[0] == 0 )
  {
    double[] missingValues = { 0.13080168776371309, 0.099156118143459912, 0.29324894514767935, 0.29324894514767935, 0.18354430379746836 };
    for ( k=0; k < 5; ++k )
      CrimeActs[0+k] = missingValues[k];
  }
  else
  {
    for ( k=0; k < 5; ++k )
      CrimeActs[0+k] = 0;
    CrimeActs[0+(int)inputs[0]-1] = 1;
  }

  /* Input 1: standard numeric pre-processing: linear shift and scale. */
  if ( inputs[1] == -9999 )
    CrimeActs[5] = 0.37844855566374552;
  else
    CrimeActs[5] = inputs[1] * 0.076923076923076927 + 0;

  /* Input 2: standard numeric pre-processing: linear shift and scale. */
  if ( inputs[2] == -9999 )
    CrimeActs[6] = 0.31445147679324897;
  else
    CrimeActs[6] = inputs[2] * 0.050000000000000003 + 0;

  /* Input 3: standard numeric pre-processing: linear shift and scale. */
  if ( inputs[3] == -9999 )
    CrimeActs[7] = 0.61345522737927805;
  else
    CrimeActs[7] = inputs[3] * 0.1111111111111111 + 0;

  /* Input 4: standard numeric pre-processing: linear shift and scale. */
  if ( inputs[4] == -9999 )
    CrimeActs[8] = 0.32876230661040784;
  else
    CrimeActs[8] = inputs[4] * 0.083333333333333329 + 0;

  /* Input 5: standard numeric pre-processing: linear shift and scale. */
  if ( inputs[5] == -9999 )
    CrimeActs[9] = 0.47009183420203526;
  else
    CrimeActs[9] = inputs[5] * 0.058823529411764705 + -0.058823529411764705;

  /* Input 6: standard numeric pre-processing: linear shift and scale. */
  if ( inputs[6] == -9999 )
    CrimeActs[10] = 0.37813353189377014;
  else
    CrimeActs[10] = inputs[6] * 0.058823529411764705 + -0.23529411764705882;

  /* Input 7: standard numeric pre-processing: linear shift and scale. */
  if ( inputs[7] == -9999 )
    CrimeActs[11] = 0.43156645569620256;
  else
    CrimeActs[11] = inputs[7] * 0.0625 + -0.125;

  /* Input 8: standard numeric pre-processing: linear shift and scale. */
  if ( inputs[8] == -9999 )
    CrimeActs[12] = 0.59361814345991559;
  else
    CrimeActs[12] = inputs[8] * 0.125 + 0;

  /* Input 9: standard numeric pre-processing: linear shift and scale. */
  if ( inputs[9] == -9999 )
    CrimeActs[13] = 0.48118846694796069;
  else
    CrimeActs[13] = inputs[9] * 0.083333333333333329 + -0.25;

  /* Input 10: standard numeric pre-processing: linear shift and scale. */
  if ( inputs[10] == -9999 )
    CrimeActs[14] = 0.33997890295358651;
  else
    CrimeActs[14] = inputs[10] * 0.050000000000000003 + 0;

  /* Input 11: standard numeric pre-processing: linear shift and scale. */
  if ( inputs[11] == -9999 )
    CrimeActs[15] = 0.32192530082825438;
  else
    CrimeActs[15] = inputs[11] * 0.037037037037037035 + -0.037037037037037035;

  /* Input 12: standard numeric pre-processing: linear shift and scale. */
  if ( inputs[12] == -9999 )
    CrimeActs[16] = 0.39587100663050029;
  else
    CrimeActs[16] = inputs[12] * 0.071428571428571425 + -0.14285714285714285;

  /* Input 13: standard numeric pre-processing: linear shift and scale. */
  if ( inputs[13] == -9999 )
    CrimeActs[17] = 0.39219409282700429;
  else
    CrimeActs[17] = inputs[13] * 0.10000000000000001 + -0.20000000000000001;

  /*
   * Process layer 1.
   */

  /* For each unit in turn */
  int ww = 0;
  int tt = 0;
  for ( u=0; u < 6; ++u )
  {
    /*
     * First, calculate post-synaptic potentials, storing
     * these in the CrimeActs array.
     */

    /* Initialise hidden unit activation to zero */
    CrimeActs[18+u] = 0.0;

    /* Accumulate weighted sum from inputs */
    for (i = 0; i < 18; ++i)
    { CrimeActs[18 + u] += w[ww] * CrimeActs[0 + i];
    ww++;
    }

    /* Subtract threshold */
    CrimeActs[18+u] -= t[tt];
    tt++;
    
    /* Now apply the hyperbolic activation function, ( e^x - e^-x ) / ( e^x + e^-x ).
     * Deal with overflow and underflow
     */
    if ( CrimeActs[18+u] > 100.0 )
       CrimeActs[18+u] = 1.0;
    else if ( CrimeActs[18+u] < -100.0 )
      CrimeActs[18+u] = -1.0;
    else
    {
        double e1 = Math.Exp(CrimeActs[18 + u]), e2 = Math.Exp(-CrimeActs[18 + u]);
      CrimeActs[18+u] = ( e1 - e2 ) / ( e1 + e2 );
    }
  }

  /*
   * Process layer 2.
   */
 
  /* For each unit in turn */
  for ( u=0; u < 1; ++u )
  {
    /*
     * First, calculate post-synaptic potentials, storing
     * these in the CrimeActs array.
     */

    /* Initialise hidden unit activation to zero */
    CrimeActs[24+u] = 0.0;

    /* Accumulate weighted sum from inputs */
    for (i = 0; i < 6; ++i)
    {
        CrimeActs[24 + u] += w[ww] * CrimeActs[18 + i];
        ww++;
    }

    /* Subtract threshold */
    CrimeActs[24+u] -= t[tt];
    tt++;
    /* Now apply the logistic activation function, 1 / ( 1 + e^-x ).
     * Deal with overflow and underflow
     */
    if ( CrimeActs[24+u] > 100.0 )
       CrimeActs[24+u] = 1.0;
    else if ( CrimeActs[24+u] < -100.0 )
      CrimeActs[24+u] = 0.0;
    else
      CrimeActs[24+u] = 1.0 / ( 1.0 + Math.Exp( - CrimeActs[24+u] ) );
  }

  /* Type of output required - selected by outputType parameter */
  switch ( outputType )
  {
    /* The usual type is to generate the output variables */
    case 0:


      /* Post-process output 0, two-state nominal output */
      if ( CrimeActs[24] >= 0.40264904170260118 )
        outputs[0] = 2.0;
      else
        outputs[0] = 1.0;
      break;

    /* type 1 is activation of output neurons */
    case 1:
      for ( i=0; i < 1; ++i )
        outputs[i] = CrimeActs[24+i];
      break;

    /* type 2 is codebook vector of winning node (lowest actn) 1st hidden layer */
    case 2:
      {
        int winner=0;
        for ( i=1; i < 6; ++i )
          if ( CrimeActs[18+i] < CrimeActs[18+winner] )
            winner=i;

        for ( i=0; i < 18; ++i )
          outputs[i] = CrimeWeights[18*winner+i];
      }
      break;

    /* type 3 indicates winning node (lowest actn) in 1st hidden layer */
    case 3:
      {
        int winner=0;
        for ( i=1; i < 6; ++i )
          if ( CrimeActs[18+i] < CrimeActs[18+winner] )
            winner=i;

        outputs[0] = winner;
      }
      break;
  }
}

/* ---------------------------------------------------------- */
/*
  CrimeRunPadded - network Crime

  inputs - the input variables, in the same number and order
  as in the data set at the time the code was generated.
  This alternative routine is useful if you want a consistent
  interface for your generated routines, so that the number
  and order of variables is the same for all of them.
  Variables (ones used as inputs marked thus *):
  0)	dang lev
  1)	edu *
    1=высшее
    2=базовое
    3=среднее
    4=средне-специальное
    5=средне-техническое
  2)	Шкала первого уровня L(СБ) *
  3)	Шкала первого уровня F(СБ) *
  4)	Шкала первого уровня K(СБ) *
  5)	Шкала первого уровня Hs(СБ) *
  6)	Шкала первого уровня D(СБ) *
  7)	Шкала первого уровня Hy(СБ) *
  8)	Шкала первого уровня Pd(СБ) *
  9)	Шкала первого уровня Mf(СБ) *
  10)	Шкала первого уровня Pa(СБ) *
  11)	Шкала первого уровня Pt(СБ) *
  12)	Шкала первого уровня Sc(СБ) *
  13)	Шкала первого уровня Ma(СБ) *
  14)	Шкала первого уровня Si(СБ) *

  Выход:
  dang lev (0)
    1=1
    2=0

*/
/* ---------------------------------------------------------- */

public static int GetCrime( int eduid, int l, int f, int k, int hs, int d, int hy, int pd, int mf, int pa, int pt, int sc, int ma, int si)
{
  double[] inp=new double[14];
    double[] outputs = new double[1];
  /* Copy inputs */
  inp[0]=eduid;
  inp[1]=l;
  inp[2]=f;
  inp[3]=k;
  inp[4]=hs;
  inp[5]=d;
  inp[6]=hy;
  inp[7]=pd;
  inp[8]=mf;
  inp[9]=pa;
  inp[10]=pt;
  inp[11]=sc;
  inp[12]=ma;
  inp[13]=si;


  /* Run the network */
  CrimeRun( inp, outputs, 0);
  if ((int)outputs[0] == 1) { return 1; }
  else { return 0; }
}




    }
}
